using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCP;

namespace NetWork
{
    public class ProtobufDecoder
    {
        public static void Decode(ByteBuf In ,ByteBuf Out)
        { 
            In.MarkReaderIndex();
            int preIndex = In.ReaderIndex();
            int length = readRawVarint32(In);
            if (preIndex != In.ReaderIndex()) {
                if (length < 0)
                {
                    
                }
                else
                {
                    if (In.ReadableBytes() < length) {
                    In.ResetReaderIndex();
                    } else
                    {
                        Out.WriteBytes(In,length); 
                    }
                }
            }
        }
        private static int readRawVarint32(ByteBuf buffer)
        {
            if (!buffer.isReadable())
            {
                return 0;
            }
            else
            {
                buffer.MarkReaderIndex();
                byte tmp = buffer.ReadByte();
                if (tmp >= 0)
                {
                    return tmp;
                }
                else
                {
                    int result = tmp & 127;
                    if (!buffer.isReadable())
                    {
                        buffer.ResetReaderIndex();
                        return 0;
                    }
                    else
                    {
                        if ((tmp = buffer.ReadByte()) >= 0)
                        {
                            result |= tmp << 7;
                        }
                        else
                        {
                            result |= (tmp & 127) << 7;
                            if (!buffer.isReadable())
                            {
                                buffer.ResetReaderIndex();
                                return 0;
                            }

                            if ((tmp = buffer.ReadByte()) >= 0)
                            {
                                result |= tmp << 14;
                            }
                            else
                            {
                                result |= (tmp & 127) << 14;
                                if (!buffer.isReadable())
                                {
                                    buffer.ResetReaderIndex();
                                    return 0;
                                }

                                if ((tmp = buffer.ReadByte()) >= 0)
                                {
                                    result |= tmp << 21;
                                }
                                else
                                {
                                    result |= (tmp & 127) << 21;
                                    if (!buffer.isReadable())
                                    {
                                        buffer.ResetReaderIndex();
                                        return 0;
                                    }

                                    result |= (tmp = buffer.ReadByte()) << 28;
                                    if (tmp < 0)
                                    {
                                       
                                    }
                                }
                            }
                        }

                        return result;
                    }
                }
            }
        }
    }
}
