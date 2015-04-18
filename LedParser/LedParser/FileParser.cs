using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedParser
{
    //Format B??
    public class FileParser : IEnumerable<IList<Color>>, IEnumerator<IList<Color>>, ICloneable
    {
        /// <summary>
        /// length of header. Must Be!
        /// </summary>
        private const int headerLength = 0x0200;

        private const int diodeMax = 600;

        private byte[] _data;
        /// <summary>
        /// How much frames stored in file
        /// </summary>
        public int NumberOfFrames
        {
            get;
            private set;
        }
        /// <summary>
        /// Length of one frame in chips(colors)
        /// </summary>
        public int FrameLength
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Binary data from file.</param>
        public FileParser(byte[] data)
        {
            InitFromData(data);
        }

        /// <summary>
        /// Inits class from binary data.
        /// </summary>
        /// <param name="data"></param>
        private void InitFromData(byte[] data)
        {
            _data = data;
            if (!(data.Length > headerLength && data[2] == 0x68 && data[3] == 0x03 && data[4] == 0x06 && data[5] == 0x06 && data[6] == 0x55 && data[headerLength - 1] == 0x55))
                throw new Exception("Unknown file format");
            NumberOfFrames = (data[0] << 8) + data[1];
            FrameLength = (data.Length - headerLength) / NumberOfFrames / 3;
        }

        /// <summary>
        /// Create new programm.
        /// </summary>
        /// <param name="frames">Number of frames</param>
        /// <param name="frameLength">number of diodes in frame.</param>
        public FileParser(int frames, int frameLength = 1024):this(frames, Color.Black, frameLength)
        {     
        }

        /// <summary>
        /// Create new programm.
        /// </summary>
        /// <param name="frames">Number of frames</param>
        /// <param name="fillColor">initial color</param>
        /// <param name="frameLength">number of diodes in frame.</param>
        public FileParser(int frames, Color fillColor, int frameLength = 1024)
        {
            if (frames < 0 || frames > 65535)
                throw new NotSupportedException("Frames parameter mest be not negative and greater than 65535");
            var data = new byte[headerLength + frameLength * frames * 3];
            data[0] = (byte)((frames & 0xFF00) >> 8);
            data[1] = (byte)(frames & 0xFF);
            data[2] = 0x68;
            data[3] = 0x03;
            data[4] = 0x06;
            data[5] = 0x06;
            for (int i = 6; i < headerLength; i++)
                data[i] = 0x55;
            for (int i = 0; i < frames * frameLength; i++)
            {
                Color color = (i % frameLength)< diodeMax ? fillColor : Color.Black;
                data[headerLength + i * 3 + 1] = ByteReverse.ReverseWithLookupTable((byte)color.R);
                data[headerLength + i * 3 + 2] = ByteReverse.ReverseWithLookupTable((byte)color.G);
                data[headerLength + i * 3 + 0] = ByteReverse.ReverseWithLookupTable((byte)color.B);
            }

            InitFromData(data);
        }

        /// <summary>
        /// sets color of one diode
        /// </summary>
        /// <param name="frame">frame number</param>
        /// <param name="diode">diode number</param>
        /// <param name="color">color to set</param>
        public void SetDiodeColor(int frame, int diode, Color color)
        {
            if (frame < 0 || frame >= NumberOfFrames)
                throw new IndexOutOfRangeException();
            if (diode < 0 || diode >= FrameLength || diode >= diodeMax)
                throw new IndexOutOfRangeException();

            int offset = headerLength + frame * FrameLength * 3;
            _data[offset + diode * 3 + 1] = ByteReverse.ReverseWithLookupTable((byte)color.R);
            _data[offset + diode * 3 + 2] = ByteReverse.ReverseWithLookupTable((byte)color.G);
            _data[offset + diode * 3 + 0] = ByteReverse.ReverseWithLookupTable((byte)color.B);

        }

        /// <summary>
        /// returns copy of bynary data file
        /// </summary>
        /// <returns></returns>
        public byte[] GetBinarySource()
        {
            return (byte[])_data.Clone();
        }

        /// <summary>
        /// returns frame
        /// </summary>
        /// <param name="i">number of frame, starts from 0</param>
        /// <returns></returns>
        public IList<Color> this[int i]
        {
            get
            {
                if (i < 0 || i >= NumberOfFrames)
                    throw new IndexOutOfRangeException(string.Format("Index must be in {0} - {1} interval.", 0, NumberOfFrames - 1));
                return GetElement(i);
            }

        }

        /// <summary>
        /// returns frame
        /// </summary>
        /// <param name="i">number of frame, starts from 0</param>
        /// <returns></returns>
        private IList<Color> GetElement(int i)
        {
            List<Color> retVal = new List<Color>(FrameLength);
            int offset = headerLength + i * FrameLength * 3; 
            for(int j = 0; j < FrameLength; j++)
            {
                retVal.Add(Color.FromArgb(
                    ByteReverse.ReverseWithLookupTable(_data[offset + j * 3 + 1]), 
                    ByteReverse.ReverseWithLookupTable(_data[offset + j * 3 + 2]), 
                    ByteReverse.ReverseWithLookupTable(_data[offset + j * 3 + 0])
                    ));
            }

            return retVal.AsReadOnly();
        }

        private int _current = -1;

        public IEnumerator<IList<Color>> GetEnumerator()
        {
            return (IEnumerator<IList<Color>>)this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public IList<Color> Current
        {
            get
            {
                return GetElement(_current);
            }
        }

        public void Dispose()
        {
            return;
        }

        object IEnumerator.Current
        {
            get { return (object)this.Current; }
        }

        public bool MoveNext()
        {
            if (_current < NumberOfFrames - 1)
            {
                ++_current;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _current = -1;
        }

		#region ICloneable Members

		/// <summary>
		/// Creates a copy with reseted state.
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			return new FileParser(this._data);
		}

		#endregion
	}
}
