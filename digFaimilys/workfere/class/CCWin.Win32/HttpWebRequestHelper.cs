using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
namespace xingwaWinFormUI.Win32
{
	public class HttpWebRequestHelper
	{
		private class UrlDecoder
		{
			private int _bufferSize;
			private byte[] _byteBuffer;
			private char[] _charBuffer;
			private Encoding _encoding;
			private int _numBytes;
			private int _numChars;
			public UrlDecoder(int bufferSize, Encoding encoding)
			{
				this._bufferSize = bufferSize;
				this._encoding = encoding;
				this._charBuffer = new char[bufferSize];
			}
			public void AddByte(byte b)
			{
				if (this._byteBuffer == null)
				{
					this._byteBuffer = new byte[this._bufferSize];
				}
				this._byteBuffer[this._numBytes++] = b;
			}
			public void AddChar(char ch)
			{
				if (this._numBytes > 0)
				{
					this.FlushBytes();
				}
				this._charBuffer[this._numChars++] = ch;
			}
			private void FlushBytes()
			{
				if (this._numBytes > 0)
				{
					this._numChars += this._encoding.GetChars(this._byteBuffer, 0, this._numBytes, this._charBuffer, this._numChars);
					this._numBytes = 0;
				}
			}
			public string GetString()
			{
				if (this._numBytes > 0)
				{
					this.FlushBytes();
				}
				if (this._numChars > 0)
				{
					return new string(this._charBuffer, 0, this._numChars);
				}
				return string.Empty;
			}
		}
		private Encoding encoding = Encoding.UTF8;
		public string Boundary
		{
			get
			{
				string[] array = this.ContentType.Split(new char[]
				{
					';'
				});
				if (array[0].Trim().ToLower() == "multipart/form-data")
				{
					string[] array2 = array[1].Split(new char[]
					{
						'='
					});
					return "--" + array2[1];
				}
				return null;
			}
		}
		public string ContentType
		{
			get
			{
				return "multipart/form-data; boundary=---------------------------7d5b915500cee";
			}
		}
		public Encoding Encoding
		{
			get
			{
				return this.encoding;
			}
			set
			{
				this.encoding = value;
			}
		}
		public byte[] CreateFieldData(string fieldName, string fieldValue)
		{
			string s = string.Format(this.Boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n", fieldName, fieldValue);
			return this.encoding.GetBytes(s);
		}
		public byte[] CreateFieldData(string fieldName, string filename, string contentType, byte[] fileBytes)
		{
			string s = "\r\n";
			string s2 = string.Format(this.Boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", fieldName, filename, contentType);
			byte[] bytes = this.encoding.GetBytes(s2);
			byte[] bytes2 = this.encoding.GetBytes(s);
			byte[] array = new byte[bytes.Length + fileBytes.Length + bytes2.Length];
			bytes.CopyTo(array, 0);
			fileBytes.CopyTo(array, bytes.Length);
			bytes2.CopyTo(array, bytes.Length + fileBytes.Length);
			return array;
		}
		public Encoding GetEncoding(HttpWebResponse response)
		{
			string text = response.ContentEncoding;
			Encoding @default = Encoding.Default;
			if (text == "")
			{
				string contentType = response.ContentType;
				if (contentType.ToLower().IndexOf("charset") != -1)
				{
					text = contentType.Substring(contentType.ToLower().IndexOf("charset=") + "charset=".Length);
				}
			}
			if (text != "")
			{
				try
				{
					@default = Encoding.GetEncoding(text);
				}
				catch
				{
				}
			}
			return @default;
		}
		private static int HexToInt(char h)
		{
			if (h >= '0' && h <= '9')
			{
				return (int)(h - '0');
			}
			if (h >= 'a' && h <= 'f')
			{
				return (int)(h - 'a' + '\n');
			}
			if (h >= 'A' && h <= 'F')
			{
				return (int)(h - 'A' + '\n');
			}
			return -1;
		}
		public static char IntToHex(int n)
		{
			if (n <= 9)
			{
				return (char)(n + 48);
			}
			return (char)(n - 10 + 97);
		}
		public static bool IsSafe(char ch)
		{
			if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9'))
			{
				return true;
			}
			if (ch != '!')
			{
				switch (ch)
				{
				case '\'':
				case '(':
				case ')':
				case '*':
				case '-':
				case '.':
					return true;
				case '+':
				case ',':
					break;
				default:
					if (ch == '_')
					{
						return true;
					}
					break;
				}
				return false;
			}
			return true;
		}
		public byte[] JoinBytes(ArrayList byteArrays)
		{
			int num = 0;
			int num2 = 0;
			string s = this.Boundary + "--\r\n";
			byte[] bytes = this.encoding.GetBytes(s);
			byteArrays.Add(bytes);
			foreach (byte[] array in byteArrays)
			{
				num += array.Length;
			}
			byte[] array2 = new byte[num];
			foreach (byte[] array3 in byteArrays)
			{
				array3.CopyTo(array2, num2);
				num2 += array3.Length;
			}
			return array2;
		}
		public string TextContent(HttpWebResponse response)
		{
			string text = "";
			Stream responseStream = response.GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream, this.GetEncoding(response));
			string str;
			while ((str = streamReader.ReadLine()) != null)
			{
				text = text + str + "\r\n";
			}
			responseStream.Close();
			return text;
		}
		public static string UrlDecode(string str)
		{
			if (str == null)
			{
				return null;
			}
			return HttpWebRequestHelper.UrlDecode(str, Encoding.UTF8);
		}
		public static string UrlDecode(string str, Encoding e)
		{
			if (str == null)
			{
				return null;
			}
			return HttpWebRequestHelper.UrlDecodeStringFromStringInternal(str, e);
		}
		private static string UrlDecodeStringFromStringInternal(string s, Encoding e)
		{
			int length = s.Length;
			HttpWebRequestHelper.UrlDecoder urlDecoder = new HttpWebRequestHelper.UrlDecoder(length, e);
			int i = 0;
			while (i < length)
			{
				char c = s[i];
				if (c == '+')
				{
					c = ' ';
					goto IL_106;
				}
				if (c != '%' || i >= length - 2)
				{
					goto IL_106;
				}
				if (s[i + 1] == 'u' && i < length - 5)
				{
					int num = HttpWebRequestHelper.HexToInt(s[i + 2]);
					int num2 = HttpWebRequestHelper.HexToInt(s[i + 3]);
					int num3 = HttpWebRequestHelper.HexToInt(s[i + 4]);
					int num4 = HttpWebRequestHelper.HexToInt(s[i + 5]);
					if (num < 0 || num2 < 0 || num3 < 0 || num4 < 0)
					{
						goto IL_106;
					}
					c = (char)(num << 12 | num2 << 8 | num3 << 4 | num4);
					i += 5;
					urlDecoder.AddChar(c);
				}
				else
				{
					int num5 = HttpWebRequestHelper.HexToInt(s[i + 1]);
					int num6 = HttpWebRequestHelper.HexToInt(s[i + 2]);
					if (num5 < 0 || num6 < 0)
					{
						goto IL_106;
					}
					byte b = (byte)(num5 << 4 | num6);
					i += 2;
					urlDecoder.AddByte(b);
				}
				IL_120:
				i++;
				continue;
				IL_106:
				if ((c & 'ﾀ') == '\0')
				{
					urlDecoder.AddByte((byte)c);
					goto IL_120;
				}
				urlDecoder.AddChar(c);
				goto IL_120;
			}
			return urlDecoder.GetString();
		}
		public static string UrlEncode(string str)
		{
			if (str == null)
			{
				return null;
			}
			return HttpWebRequestHelper.UrlEncode(str, Encoding.UTF8);
		}
		public static string UrlEncode(string str, Encoding e)
		{
			if (str == null)
			{
				return null;
			}
			return Encoding.ASCII.GetString(HttpWebRequestHelper.UrlEncodeToBytes(str, e));
		}
		private static byte[] UrlEncodeBytesToBytesInternal(byte[] bytes, int offset, int count, bool alwaysCreateReturnValue)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < count; i++)
			{
				char c = (char)bytes[offset + i];
				if (c == ' ')
				{
					num++;
				}
				else
				{
					if (!HttpWebRequestHelper.IsSafe(c))
					{
						num2++;
					}
				}
			}
			if (!alwaysCreateReturnValue && num == 0 && num2 == 0)
			{
				return bytes;
			}
			byte[] array = new byte[count + num2 * 2];
			int num3 = 0;
			for (int j = 0; j < count; j++)
			{
				byte b = bytes[offset + j];
				char c2 = (char)b;
				if (HttpWebRequestHelper.IsSafe(c2))
				{
					array[num3++] = b;
				}
				else
				{
					if (c2 == ' ')
					{
						array[num3++] = 43;
					}
					else
					{
						array[num3++] = 37;
						array[num3++] = (byte)HttpWebRequestHelper.IntToHex(b >> 4 & 15);
						array[num3++] = (byte)HttpWebRequestHelper.IntToHex((int)(b & 15));
					}
				}
			}
			return array;
		}
		public static byte[] UrlEncodeToBytes(byte[] bytes)
		{
			if (bytes == null)
			{
				return null;
			}
			return HttpWebRequestHelper.UrlEncodeToBytes(bytes, 0, bytes.Length);
		}
		public static byte[] UrlEncodeToBytes(string str, Encoding e)
		{
			if (str == null)
			{
				return null;
			}
			byte[] bytes = e.GetBytes(str);
			return HttpWebRequestHelper.UrlEncodeBytesToBytesInternal(bytes, 0, bytes.Length, false);
		}
		public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
		{
			if (bytes == null && count == 0)
			{
				return null;
			}
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			if (offset < 0 || offset > bytes.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || offset + count > bytes.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			return HttpWebRequestHelper.UrlEncodeBytesToBytesInternal(bytes, offset, count, true);
		}
	}
}
