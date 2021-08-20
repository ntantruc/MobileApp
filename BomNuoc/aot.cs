#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

namespace BomNuoc.Resolvers
{
    using System;
    using System.Collections.Generic;
    using MessagePack;

    public class GeneratedResolver : global::MessagePack.IFormatterResolver
    {
        public static readonly global::MessagePack.IFormatterResolver Instance = new GeneratedResolver();

        GeneratedResolver()
        {

        }

        public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.formatter;
        }

        static class FormatterCache<T>
        {
            public static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> formatter;

            static FormatterCache()
            {
                var f = GeneratedResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                }
            }
        }
    }

    internal static class GeneratedResolverGetFormatterHelper
    {
        static readonly global::System.Collections.Generic.Dictionary<Type, int> lookup;

        static GeneratedResolverGetFormatterHelper()
        {
            lookup = new global::System.Collections.Generic.Dictionary<Type, int>(57)
            {
                
                {typeof(global::BomNuoc.SSL.SSLCommands.SQLExecuteReader.SQLCommands), 0 },
                {typeof(global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary.SQLCommands), 1 },
                {typeof(global::BomNuoc.SQL.SQLTables.TableBase), 2 },
                {typeof(global::BomNuoc.SQL.SQLTables.TestTable), 3 },
                {typeof(global::BomNuoc.SQL.SQLTables.UserListFormatter), 4 },
                {typeof(global::BomNuoc.SQL.SQLTables.User), 5 },
                {typeof(global::BomNuoc.SQL.SQLTables.UserTypes), 6 },
                {typeof(global::BomNuoc.SQL.SQLTables.Cabinets), 7 },
                {typeof(global::BomNuoc.SQL.SQLTables.CabinetsRecords), 8 },
                {typeof(global::BomNuoc.SQL.SQLTables.Cooperative), 9 },
                {typeof(global::BomNuoc.SQL.SQLTables.Environment), 10 },
                {typeof(global::BomNuoc.SQL.SQLTables.Field), 11 },
                {typeof(global::BomNuoc.SQL.SQLTables.Ground), 12 },
                {typeof(global::BomNuoc.SQL.SQLTables.Notifications), 13 },
                {typeof(global::BomNuoc.SQL.SQLTables.Province), 14 },
                {typeof(global::BomNuoc.SQL.SQLTables.Water), 15 },                

                {typeof(global::BomNuoc.SSL.SSLCommands), 16 },
                {typeof(global::BomNuoc.SSL.SSLCommands.SSLCommandBase), 17 },
                {typeof(global::BomNuoc.SSL.SSLCommands.Acknowledgement), 18 },
                {typeof(global::BomNuoc.SSL.SSLCommands.TestMessage), 19 },
                {typeof(global::BomNuoc.SSL.SSLCommands.Login), 20 },
                {typeof(global::BomNuoc.SSL.SSLCommands.UpdateToken), 21 },
                {typeof(global::BomNuoc.SSL.SSLCommands.NeedRelogin), 22 },
                {typeof(global::BomNuoc.SSL.SSLCommands.SQLExecuteReader), 23 },
                {typeof(global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary), 24 },
                {typeof(global::BomNuoc.SSL.SSLCommands.ErrorMessage), 25 },
                {typeof(global::BomNuoc.SSL.SSLCommands.UpdateData), 26 },
                {typeof(global::BomNuoc.SSL.SSLCommands.RequestCabinetsOnOffData), 27 },
                {typeof(global::BomNuoc.SSL.SSLCommands.SendCabinetsOnOffData), 28 },

                { typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.TableBase>),                        29                                     },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.TestTable>),                        30                                     },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.UserListFormatter>),                31                                             },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.User>),                             32                                },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.UserTypes>),                        33                                     },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.Cabinets>),                          34                                   },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.CabinetsRecords>),                            35                                 },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.Cooperative>),             36                                                },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.Environment>),                     37                                        },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.Field>),            38                                                 },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.Ground>),                  39                                           },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.Notifications>),                        40                                     },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.Province>),                     41                                        },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.Water>),                          42                                   },

                { typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands>),                                43                             },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.SSLCommandBase>),                 44                                            },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.Acknowledgement>),                45                                             },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.TestMessage>),                    46                                         },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.Login>),                          47                                   },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.UpdateToken>),                    48                                         },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.NeedRelogin>),                    49                                         },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.SQLExecuteReader>),               50                                              },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary>),         51                                                    },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.ErrorMessage>),                   52                                          },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.UpdateData>),                     53                                        },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.RequestCabinetsOnOffData>),           54                                                  },
                {typeof(System.Collections.Generic.List<global::BomNuoc.SSL.SSLCommands.SendCabinetsOnOffData>),               55                                              },
                {typeof(System.DateTime),               56                                              },
            };
        }

        internal static object GetFormatter(Type t)
        {
            int key;
            if (!lookup.TryGetValue(t, out key)) return null;

            switch (key)
            {
                
                case 0: return new BomNuoc.Formatters.BomNuoc.SSL.SQLCommandsFormatter();
                case 1: return new BomNuoc.Formatters.BomNuoc.SSL.SQLCommandsBinaryFormatter();
                case 2: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.TableBaseFormatter();
                case 3: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.TestTableFormatter();
                case 4: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.UserListFormatterFormatter();
                case 5: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.UserFormatter();
                case 6: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.UserTypesFormatter();
                case 7: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.CabinetsFormatter();
                case 8: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.CabinetsRecordsFormatter();
                case 9: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.CooperativeFormatter();
                case 10: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.EnvironmentFormatter();
                case 11: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.FieldFormatter();
                case 12: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.GroundFormatter();
                case 13: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.NotificationsFormatter();
                case 14: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.ProvinceFormatter();
                case 15: return new BomNuoc.Formatters.BomNuoc.SQL.SQLTables.WaterFormatter();
                case 16: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommandsFormatter();
                case 17: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_SSLCommandBaseFormatter();
                case 18: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_AcknowledgementFormatter();
                case 19: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_TestMessageFormatter();
                case 20: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_LoginFormatter();
                case 21: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_UpdateTokenFormatter();
                case 22: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_NeedReloginFormatter();
                case 23: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_SQLExecuteReaderFormatter();
                case 24: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_SQLExecuteReaderBinaryFormatter();
                case 25: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_ErrorMessageFormatter();
                case 26: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_UpdateDataFormatter();
                case 27: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_RequestCabinetsOnOffDataFormatter();
                case 28: return new BomNuoc.Formatters.BomNuoc.SSL.SSLCommands_SendCabinetsOnOffDataFormatter();
                case 29: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.TableBase>();
                case 30: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.TestTable>();
                case 31: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.UserListFormatter>();
                case 32: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.User>();
                case 33: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.UserTypes>();
                case 34: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.Cabinets>();
                case 35: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.CabinetsRecords>();
                case 36: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.Cooperative>();
                case 37: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.Environment>();
                case 38: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.Field>();
                case 39: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.Ground>();
                case 40: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.Notifications>();
                case 41: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.Province>();
                case 42: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SQL.SQLTables.Water>();
                case 43: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands>();
                case 44: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.SSLCommandBase>();
                case 45: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.Acknowledgement>();
                case 46: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.TestMessage>();
                case 47: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.Login>();
                case 48: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.UpdateToken>();
                case 49: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.NeedRelogin>();
                case 50: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.SQLExecuteReader>();
                case 51: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary>();
                case 52: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.ErrorMessage>();
                case 53: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.UpdateData>();
                case 54: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.RequestCabinetsOnOffData>();
                case 55: return new MessagePack.Formatters.ListFormatter<global::BomNuoc.SSL.SSLCommands.SendCabinetsOnOffData>();
                case 56: return new BomNuoc.Formatters.Native.NativeDateTimeFormatter();
                

                default: return null;
            }
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

namespace BomNuoc.Formatters.Native
{
    using System;
    using MessagePack;

    public sealed class NativeDateTimeFormatter : MessagePack.Formatters.IMessagePackFormatter<DateTime>
    {
        public static readonly NativeDateTimeFormatter Instance = new NativeDateTimeFormatter();

        public int Serialize(ref byte[] bytes, int offset, System.DateTime value, MessagePack.IFormatterResolver formatterResolver)
        {
            var dateData = value.ToBinary();
            return MessagePackBinary.WriteInt64(ref bytes, offset, dateData);
        }

        public DateTime Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            //if (MessagePackBinary.GetMessagePackType(bytes, offset) == MessagePackType.Extension)
            //{
            //    return DateTimeFormatter.Instance.Deserialize(bytes, offset, formatterResolver, out readSize);
            //}

            var dateData = MessagePackBinary.ReadInt64(bytes, offset, out readSize);
            return System.DateTime.FromBinary(dateData);
        }
    }
}

namespace BomNuoc.Formatters.BomNuoc.SSL
{
    using System;
    using MessagePack;

    public sealed class SQLCommandsFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.SQLExecuteReader.SQLCommands>
    {
        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.SQLExecuteReader.SQLCommands value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public global::BomNuoc.SSL.SSLCommands.SQLExecuteReader.SQLCommands Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            return (global::BomNuoc.SSL.SSLCommands.SQLExecuteReader.SQLCommands)MessagePackBinary.ReadInt32(bytes, offset, out readSize);
        }
    }
    
    public sealed class SQLCommandsBinaryFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary.SQLCommands>
    {
        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary.SQLCommands value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary.SQLCommands Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            return (global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary.SQLCommands)MessagePackBinary.ReadInt32(bytes, offset, out readSize);
        }
    }
    

}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612


#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

namespace BomNuoc.Formatters.BomNuoc.SQL.SQLTables
{
    using System;
    using MessagePack;

    public static class UTCToLocalTime
    {
        //private static TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        private static TimeZoneInfo cstZone = null;
        static UTCToLocalTime()
        {
            try
            {
              //  System.Diagnostics.Debug.WriteLine("==============> Truc utc time getting id...");
                if ((Device.RuntimePlatform == Device.iOS) | (Device.RuntimePlatform == Device.Android))
                {
                    cstZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Jakarta");
                }  else
                {
                    cstZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                    //cstZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Jakarta");
                }
                
                //System.Diagnostics.Debug.WriteLine("==============> Truc utc time getting id...DONE");
            } catch
            {
                //System.Diagnostics.Debug.WriteLine("==============> Truc utc time getting id ... Exception");
            }
            
    }
        public static DateTime? ConvertUTCToLocalTime(DateTime? utctime)
        {
            //return global::System.TimeZoneInfo.ConvertTimeFromUtc(utctime ?? DateTime.Now, cstZone);
            try
            {
                //System.Diagnostics.Debug.WriteLine("==============> Truc utc time converting...");
                if (utctime == null)
                    return null;
                return global::System.TimeZoneInfo.ConvertTimeFromUtc(utctime?? DateTime.Now, cstZone);
                //return utctime;
                

                // convert to device's Local timezone
                //return TimeZoneInfo.ConvertTime(convertDate, cstZone, TimeZoneInfo.Local);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("==============> Truc utc time converting...Exception");
                return utctime;
            }
            

        }       


    }
    public sealed class TableBaseFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.TableBase>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public TableBaseFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "ID", 0},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.TableBase value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 1);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.TableBase Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.TableBase();
            ____result.ID = __ID__;
            return ____result;
        }
    }


    public sealed class TestTableFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.TestTable>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public TestTableFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "CreateDate", 0},
                { "AppID", 1},
                { "TestField", 2},
                { "ID", 3},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CreateDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TestField"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.TestTable value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 4);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime>().Serialize(ref bytes, offset, value.CreateDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.TestField, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.TestTable Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __CreateDate__ = default(global::System.DateTime);
            var __AppID__ = default(string);
            var __TestField__ = default(string);
            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __CreateDate__ = formatterResolver.GetFormatterWithVerify<global::System.DateTime>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __TestField__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.TestTable();
            ____result.CreateDate = __CreateDate__;
            ____result.AppID = __AppID__;
            ____result.TestField = __TestField__;
            ____result.ID = __ID__;
            return ____result;
        }
    }



    public sealed class UserTypesFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.UserTypes>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public UserTypesFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
            };

            this.____stringByteKeys = new byte[][]
            {

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.UserTypes value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 0);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.UserTypes Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;


            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.UserTypes();
            return ____result;
        }
    }

    
    public sealed class UserListFormatterFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.UserListFormatter>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public UserListFormatterFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "UserList", 0},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("UserList"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.UserListFormatter value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 1);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.User>>().Serialize(ref bytes, offset, value.UserList, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.UserListFormatter Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __UserList__ = default(global::System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.User>);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __UserList__ = formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.List<global::BomNuoc.SQL.SQLTables.User>>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.UserListFormatter();
            ____result.UserList = __UserList__;
            return ____result;
        }
    }


    public sealed class UserFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.User>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public UserFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "CreateDate", 0},
                { "AppID", 1},
                { "UserName", 2},
                { "Password", 3},
                { "ViewName", 4},
                { "UserType", 5},
                { "CabinetsID", 6},
                { "MailAddress", 7},
                { "IsEnable", 8},
                { "token", 9},
                { "tokenDate", 10},
                { "CreateUser", 11},
                { "LastLoginDate", 12},
                { "LastLogoutDate", 13},
                { "LastLoginIP", 14},
                { "ProvinceName", 15},
                { "CooperateName", 16},
                { "ExpiredDate", 17},
                { "IsExpired", 18},
                { "Reserved1", 19},
                { "Reserved2", 20},
                { "Reserved3", 21},
                { "Reserved4", 22},
                { "ID", 23},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CreateDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("UserName"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Password"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ViewName"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("UserType"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CabinetsID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("MailAddress"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("IsEnable"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("tokenDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CreateUser"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("LastLoginDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("LastLogoutDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("LastLoginIP"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ProvinceName"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CooperateName"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ExpiredDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("IsExpired"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved1"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved2"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved3"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved4"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.User value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteMapHeader(ref bytes, offset, 24);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.CreateDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.UserName, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Password, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.ViewName, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.UserType, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += formatterResolver.GetFormatterWithVerify<int?>().Serialize(ref bytes, offset, value.CabinetsID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[7]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.MailAddress, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[8]);
            offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.IsEnable);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[9]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[10]);            
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.tokenDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[11]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.CreateUser, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[12]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.LastLoginDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[13]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.LastLogoutDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[14]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.LastLoginIP, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[15]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.ProvinceName, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[16]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.CooperateName, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[17]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.ExpiredDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[18]);
            offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.IsExpired);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[19]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved1, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[20]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved2, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[21]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved3, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[22]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved4, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[23]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.User Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __CreateDate__ = default(global::System.DateTime?);
            var __AppID__ = default(string);
            var __UserName__ = default(string);
            var __Password__ = default(string);
            var __ViewName__ = default(string);
            var __UserType__ = default(string);
            var __CabinetsID__ = default(int);
            var __MailAddress__ = default(string);
            var __IsEnable__ = default(bool);
            var __token__ = default(string);
            var __tokenDate__ = default(global::System.DateTime?);
            var __CreateUser__ = default(string);
            var __LastLoginDate__ = default(global::System.DateTime?);
            var __LastLogoutDate__ = default(global::System.DateTime?);
            var __LastLoginIP__ = default(string);
            var __ProvinceName__ = default(string);
            var __CooperativeName__ = default(string);
            var __ExpiredDate__ = default(global::System.DateTime?);
            var __IsExpired__ = default(bool);
            var __Reserved1__ = default(string);
            var __Reserved2__ = default(string);
            var __Reserved3__ = default(string);
            var __Reserved4__ = default(string);
            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }
                switch (key)
                {
                    case 0:
                        __CreateDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));                        
                        break;
                    case 1:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __UserName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __Password__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 4:
                        __ViewName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 5:
                        __UserType__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 6:
                        __CabinetsID__ = formatterResolver.GetFormatterWithVerify<int>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 7:
                        __MailAddress__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 8:
                        __IsEnable__ = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
                        break;
                    case 9:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 10:
                        __tokenDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 11:
                        __CreateUser__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 12:
                        __LastLoginDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 13:
                        __LastLogoutDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 14:
                        __LastLoginIP__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 15:
                        __ProvinceName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 16:
                        __CooperativeName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 17:
                        __ExpiredDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 18:
                        __IsExpired__ = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
                        break;
                    case 19:
                        __Reserved1__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 20:
                        __Reserved2__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 21:
                        __Reserved3__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 22:
                        __Reserved4__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 23:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.User();
            ____result.CreateDate = __CreateDate__;
            ____result.AppID = __AppID__;
            ____result.UserName = __UserName__;
            ____result.Password = __Password__;
            ____result.ViewName = __ViewName__;
            ____result.UserType = __UserType__;
            ____result.CabinetsID = __CabinetsID__;
            ____result.MailAddress = __MailAddress__;
            ____result.IsEnable = __IsEnable__;
            ____result.token = __token__;
            ____result.tokenDate = __tokenDate__;
            ____result.CreateUser = __CreateUser__;
            ____result.LastLoginDate = __LastLoginDate__;
            ____result.LastLogoutDate = __LastLogoutDate__;
            ____result.LastLoginIP = __LastLoginIP__;
            ____result.ProvinceName = __ProvinceName__;
            ____result.CooperateName = __CooperativeName__;
            ____result.ExpiredDate = __ExpiredDate__;
            ____result.IsExpired = __IsExpired__;
            ____result.Reserved1 = __Reserved1__;
            ____result.Reserved2 = __Reserved2__;
            ____result.Reserved3 = __Reserved3__;
            ____result.Reserved4 = __Reserved4__;
            ____result.ID = __ID__;
            return ____result;
        }
    }


    public sealed class CabinetsFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.Cabinets>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public CabinetsFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "CreateDate", 0},
                { "ModifyDate", 1},
                { "AppID", 2},
                { "CabinetsProductKey", 3},
                { "GatewaySerialNumber", 4},
                { "GatewayLastLoginDate", 5},
                { "GatewayLastLogoutDate", 6},
                { "GatewayLastLoginIP", 7},
                { "Reserved1", 8},
                { "Reserved2", 9},
                { "Reserved3", 10},
                { "Reserved4", 11},
                { "Reserved5", 12},
                { "Reserved6", 13},
                { "ID", 14},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CreateDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ModifyDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CabinetsProductKey"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("GatewaySerialNumber"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("GatewayLastLoginDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("GatewayLastLogoutDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("GatewayLastLoginIP"),                
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved1"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved2"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved3"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved4"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved5"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved6"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.Cabinets value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteMapHeader(ref bytes, offset, 15);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.CreateDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.ModifyDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.CabinetsProductKey, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.GatewaySerialNumber, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.GatewayLastLoginDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.GatewayLastLogoutDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[7]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.GatewayLastLoginIP, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[8]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved1, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[9]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved2, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[10]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved3, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[11]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved4, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[12]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved5, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[13]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved6, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[14]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.Cabinets Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __CreateDate__ = default(global::System.DateTime?);
            var __ModifyDate__ = default(global::System.DateTime?);
            var __AppID__ = default(string);
            var __CabinetsProductKey__ = default(string);

            var __GatewaySerialNumber__ = default(string);
            var __GatewayLastLoginDate__ = default(global::System.DateTime?);
            var __GatewayLastLogoutDate__ = default(global::System.DateTime?);
            var __GatewayLastLoginIP__ = default(string);

            var __Reserved1__ = default(string);
            var __Reserved2__ = default(string);
            var __Reserved3__ = default(string);
            var __Reserved4__ = default(string);
            var __Reserved5__ = default(string);
            var __Reserved6__ = default(string);
            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __CreateDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 1:
                        __ModifyDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 2:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __CabinetsProductKey__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 4:
                        __GatewaySerialNumber__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 5:
                        __GatewayLastLoginDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 6:
                        __GatewayLastLogoutDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;

                    case 7:
                        __GatewayLastLoginIP__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 8:
                        __Reserved1__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 9:
                        __Reserved2__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 10:
                        __Reserved3__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 11:
                        __Reserved4__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 12:
                        __Reserved5__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 13:
                        __Reserved6__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 14:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.Cabinets();
            ____result.CreateDate = __CreateDate__;
            ____result.ModifyDate = __ModifyDate__;
            ____result.AppID = __AppID__;
            ____result.CabinetsProductKey = __CabinetsProductKey__;
            ____result.GatewaySerialNumber = __GatewaySerialNumber__;
            ____result.GatewayLastLoginDate = __GatewayLastLoginDate__;
            ____result.GatewayLastLogoutDate = __GatewayLastLogoutDate__;
            ____result.GatewayLastLoginIP = __GatewayLastLoginIP__;
            ____result.Reserved1 = __Reserved1__;
            ____result.Reserved2 = __Reserved2__;
            ____result.Reserved3 = __Reserved3__;
            ____result.Reserved4 = __Reserved4__;
            ____result.Reserved5 = __Reserved5__;
            ____result.Reserved5 = __Reserved6__;
            ____result.ID = __ID__;
            return ____result;
        }
    }

    public sealed class CabinetsRecordsFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.CabinetsRecords>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public CabinetsRecordsFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "CreateDate", 0},
                { "CabinetsID", 1},
                { "FieldID", 2},
                { "TimeOn", 3},
                { "TimeOff", 4},
                { "TotalWateringTime", 5},
                { "CompletedWateringLevel", 6},                
                { "InsertDate", 7},
                { "Reserved1", 8},
                { "Reserved2", 9},
                { "ID", 10},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CreateDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CabinetsID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("FieldID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TimeOn"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TimeOff"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TotalWateringTime"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CompletedWateringLevel"),                
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("InsertDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved1"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved2"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.CabinetsRecords value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteMapHeader(ref bytes, offset, 11);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.CreateDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.CabinetsID);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.FieldID);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.TimeOn, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.TimeOff, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.TotalWateringTime);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.CompletedWateringLevel);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[7]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.InsertDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[8]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved1, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[9]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved2, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[10]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.CabinetsRecords Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __CreateDate__ = default(global::System.DateTime?);
            var __CabinetsID__ = default(int);
            var __FieldID__ = default(int);
            var __TimeOn__ = default(global::System.DateTime?);
            var __TimeOff__ = default(global::System.DateTime?);
            var __TotalWateringTime__ = default(int);
            var __CompletedWateringLevel__ = default(int);
            var __InsertDate__ = default(global::System.DateTime?);
            var __Reserved1__ = default(string);
            var __Reserved2__ = default(string);
            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __CreateDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));                       
                        break;
                    case 1:
                        __CabinetsID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 2:
                        __FieldID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 3:
                        __TimeOn__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 4:
                        __TimeOff__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 5:
                        __TotalWateringTime__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 6:
                        __CompletedWateringLevel__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 7:
                        __InsertDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 8:
                        __Reserved1__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 9:
                        __Reserved2__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 10:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.CabinetsRecords();
            ____result.CreateDate = __CreateDate__;
            ____result.CabinetsID = __CabinetsID__;
            ____result.FieldID = __FieldID__;
            ____result.TimeOn = __TimeOn__;
            ____result.TimeOff = __TimeOff__;
            ____result.TotalWateringTime = __TotalWateringTime__;
            ____result.CompletedWateringLevel = __CompletedWateringLevel__;
            ____result.InsertDate = __InsertDate__;
            ____result.Reserved1 = __Reserved1__;
            ____result.Reserved2 = __Reserved2__;
            ____result.ID = __ID__;
            return ____result;
        }
    }

    public sealed class CooperativeFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.Cooperative>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public CooperativeFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "CreateDate", 0},
                { "CooperateName", 1},
                { "ProvinceName", 2},
                { "CabinetsID", 3},
                { "Reserved1", 4},
                { "Reserved2", 5},
                { "ID", 6},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CreateDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CooperateName"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ProvinceName"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CabinetsID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved1"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved2"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.Cooperative value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteMapHeader(ref bytes, offset, 7);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.CreateDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.CooperateName, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.ProvinceName, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.CabinetsID);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved1, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved2, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.Cooperative Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __CreateDate__ = default(global::System.DateTime?);
            var __CooperativeName__ = default(string);
            var __ProvinceName__ = default(string);
            var __CabinetsID__ = default(int);
            var __Reserved1__ = default(string);
            var __Reserved2__ = default(string);
            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __CreateDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 1:
                        __CooperativeName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __ProvinceName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __CabinetsID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 4:
                        __Reserved1__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 5:
                        __Reserved2__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 6:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.Cooperative();
            ____result.CreateDate = __CreateDate__;
            ____result.CooperateName = __CooperativeName__;
            ____result.ProvinceName = __ProvinceName__;
            ____result.CabinetsID = __CabinetsID__;
            ____result.Reserved1 = __Reserved1__;
            ____result.Reserved2 = __Reserved2__;
            ____result.ID = __ID__;
            return ____result;
        }
    }


    public sealed class EnvironmentFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.Environment>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public EnvironmentFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "FieldID", 0},
                { "TempMinLevel", 1},
                { "TempMaxLevel", 2},
                { "TempLevelValue", 3},
                { "UpdateDate", 4},
                { "Reserved1", 5},
                { "Reserved2", 6},
                { "Reserved3", 7},
                { "Reserved4", 8},
                { "Reserved5", 9},
                { "Reserved6", 10},
                { "ID", 11},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("FieldID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TempMinLevel"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TempMaxLevel"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TempLevelValue"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("UpdateDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved1"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved2"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved3"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved4"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved5"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved6"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.Environment value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteMapHeader(ref bytes, offset, 12);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.FieldID);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.TempMinLevel);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.TempMaxLevel);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.TempLevelValue);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.UpdateDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved1, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved2, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[7]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved3, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[8]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved4, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[9]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved5, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[10]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved6, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[11]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.Environment Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __FieldID__ = default(int);
            var __TempMinLevel__ = default(int);
            var __TempMaxLevel__ = default(int);
            var __TempLevelValue__ = default(int);
            var __UpdateDate__ = default(global::System.DateTime?);
            var __Reserved1__ = default(string);
            var __Reserved2__ = default(string);
            var __Reserved3__ = default(string);
            var __Reserved4__ = default(string);
            var __Reserved5__ = default(string);
            var __Reserved6__ = default(string);
            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __FieldID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 1:
                        __TempMinLevel__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 2:
                        __TempMaxLevel__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 3:
                        __TempLevelValue__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 4:
                        __UpdateDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 5:
                        __Reserved1__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 6:
                        __Reserved2__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 7:
                        __Reserved3__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 8:
                        __Reserved4__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 9:
                        __Reserved5__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 10:
                        __Reserved6__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 11:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.Environment();
            ____result.FieldID = __FieldID__;
            ____result.TempMinLevel = __TempMinLevel__;
            ____result.TempMaxLevel = __TempMaxLevel__;
            ____result.TempLevelValue = __TempLevelValue__;
            ____result.UpdateDate = __UpdateDate__;
            ____result.Reserved1 = __Reserved1__;
            ____result.Reserved2 = __Reserved2__;
            ____result.Reserved3 = __Reserved3__;
            ____result.Reserved4 = __Reserved4__;
            ____result.Reserved5 = __Reserved5__;
            ____result.Reserved6 = __Reserved6__;

            ____result.ID = __ID__;
            return ____result;
        }
    }


    public sealed class FieldFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.Field>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public FieldFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                
                { "FieldOrder", 0},
                { "FieldNameNumber", 1},
                { "FieldDescription", 2},
                { "CabinetsID", 3},
                { "PowerOnOff", 4},
                { "TimeOn", 5},
                { "TimeOff", 6},
                { "TotalWateringTime", 7},
                { "NotificationsID", 8},
                { "LimitedWatteringTime", 9},
                { "IsAlive", 10},
                { "UpdateDate", 11},
                { "RiverLevelMin", 12 },
                { "RiverLevelValue", 13 },
                { "NumberACLostPhases", 14 },
                { "Reserved1", 15},
                { "Reserved2", 16},
                { "Reserved3", 17},
                { "Reserved4", 18},
                { "Reserved5", 19},
                { "Reserved6", 20},
                { "ID", 21},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("FieldOrder"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("FieldNameNumber"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("FieldDescription"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CabinetsID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("PowerOnOff"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TimeOn"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TimeOff"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TotalWateringTime"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("NotificationsID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("LimitedWatteringTime"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("IsAlive"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("UpdateDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RiverLevelMin"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RiverLevelValue"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("NumberACLostPhases"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved1"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved2"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved3"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved4"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved5"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved6"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.Field value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteMapHeader(ref bytes, offset, 22);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.FieldOrder);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.FieldNameNumber, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.FieldDescription, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.CabinetsID);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.PowerOnOff);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.TimeOn, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.TimeOff, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[7]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.TotalWateringTime);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[8]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.NotificationsID);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[9]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.LimitedWatteringTime);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[10]);
            offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.IsAlive);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[11]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.UpdateDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[12]);
            offset += formatterResolver.GetFormatterWithVerify<double?>().Serialize(ref bytes, offset, value.RiverLevelMin, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[13]);
            offset += formatterResolver.GetFormatterWithVerify<double?>().Serialize(ref bytes, offset, value.RiverLevelValue, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[14]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.NumberACLostPhases);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[15]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved1, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[16]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved2, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[17]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved3, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[18]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved4, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[19]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved5, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[20]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved6, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[21]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.Field Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;
            var __FieldOrder__ = default(int);
            var __FieldNameNumber__ = default(string);
            var __FieldDescription__ = default(string);
            var __CabinetsID__ = default(int);
            var __PowerOnOff__ = default(bool);
            var __TimeOn__ = default(global::System.DateTime?);
            var __TimeOff__ = default(global::System.DateTime?);
            var __TotalWateringTime__ = default(int);
            var __NotificationsID__ = default(int);
            var __LimitedWatteringTime__ = default(int);
            var __IsAlive__ = default(bool);
            var __UpdateDate__ = default(global::System.DateTime?);
            var __RiverLevelMin__ = default(double?);
            var __RiverLevelValue__ = default(double?);
            var __NumberACLostPhases__ = default(int);
            var __Reserved1__ = default(string);
            var __Reserved2__ = default(string);
            var __Reserved3__ = default(string);
            var __Reserved4__ = default(string);
            var __Reserved5__ = default(string);
            var __Reserved6__ = default(string);
            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __FieldOrder__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 1:
                        __FieldNameNumber__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __FieldDescription__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __CabinetsID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 4:
                        __PowerOnOff__ = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
                        break;
                    case 5:
                        __TimeOn__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 6:
                        __TimeOff__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 7:
                        __TotalWateringTime__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 8:
                        __NotificationsID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 9:
                        __LimitedWatteringTime__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 10:
                        __IsAlive__ = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
                        break;
                    case 11:
                        __UpdateDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 12:
                        __RiverLevelMin__ = formatterResolver.GetFormatterWithVerify<double?>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 13:
                        __RiverLevelValue__ = formatterResolver.GetFormatterWithVerify<double?>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 14:
                        __NumberACLostPhases__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 15:
                        __Reserved1__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 16:
                        __Reserved2__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 17:
                        __Reserved3__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 18:
                        __Reserved4__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 19:
                        __Reserved5__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 20:
                        __Reserved6__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 21:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.Field();
            ____result.FieldOrder = __FieldOrder__;
            ____result.FieldNameNumber = __FieldNameNumber__;
            ____result.FieldDescription = __FieldDescription__;
            ____result.CabinetsID = __CabinetsID__;
            ____result.PowerOnOff = __PowerOnOff__;
            ____result.TimeOn = __TimeOn__;
            ____result.TimeOff = __TimeOff__;
            ____result.TotalWateringTime = __TotalWateringTime__;
            ____result.NotificationsID = __NotificationsID__;
            ____result.LimitedWatteringTime = __LimitedWatteringTime__;
            ____result.IsAlive = __IsAlive__;
            ____result.UpdateDate = __UpdateDate__;
            ____result.RiverLevelMin = __RiverLevelMin__;
            ____result.RiverLevelValue = __RiverLevelValue__;
            ____result.NumberACLostPhases = __NumberACLostPhases__;
            ____result.Reserved1 = __Reserved1__;
            ____result.Reserved2 = __Reserved2__;
            ____result.Reserved3 = __Reserved3__;
            ____result.Reserved4 = __Reserved4__;
            ____result.Reserved5 = __Reserved5__;
            ____result.Reserved6 = __Reserved6__;

            ____result.ID = __ID__;
            return ____result;
        }
    }



    public sealed class GroundFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.Ground>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public GroundFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "FieldID", 0},
                { "GroundMinLevel", 1},
                { "GroundMaxLevel", 2},
                { "GroundLevelValue", 3},
                { "UpdateDate", 4},
                { "Reserved1", 5},
                { "Reserved2", 6},
                { "Reserved3", 7},
                { "Reserved4", 8},
                { "Reserved5", 9},
                { "Reserved6", 10},
                { "ID", 11},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("FieldID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("GroundMinLevel"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("GroundMaxLevel"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("GroundLevelValue"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("UpdateDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved1"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved2"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved3"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved4"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved5"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved6"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.Ground value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteMapHeader(ref bytes, offset, 12);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.FieldID);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.GroundMinLevel);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.GroundMaxLevel);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.GroundLevelValue);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.UpdateDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved1, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved2, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[7]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved3, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[8]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved4, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[9]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved5, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[10]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved6, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[11]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.Ground Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __FieldID__ = default(int);
            var __GroundMinLevel__ = default(int);
            var __GroundMaxLevel__ = default(int);
            var __GroundLevelValue__ = default(int);
            var __UpdateDate__ = default(global::System.DateTime?);
            var __Reserved1__ = default(string);
            var __Reserved2__ = default(string);
            var __Reserved3__ = default(string);
            var __Reserved4__ = default(string);
            var __Reserved5__ = default(string);
            var __Reserved6__ = default(string);
            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __FieldID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 1:
                        __GroundMinLevel__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 2:
                        __GroundMaxLevel__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 3:
                        __GroundLevelValue__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 4:
                        __UpdateDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 5:
                        __Reserved1__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 6:
                        __Reserved2__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 7:
                        __Reserved3__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 8:
                        __Reserved4__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 9:
                        __Reserved5__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 10:
                        __Reserved6__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 11:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.Ground();
            ____result.FieldID = __FieldID__;
            ____result.GroundMinLevel = __GroundMinLevel__;
            ____result.GroundMaxLevel = __GroundMaxLevel__;
            ____result.GroundLevelValue = __GroundLevelValue__;
            ____result.UpdateDate = __UpdateDate__;
            ____result.Reserved1 = __Reserved1__;
            ____result.Reserved2 = __Reserved2__;
            ____result.Reserved3 = __Reserved3__;
            ____result.Reserved4 = __Reserved4__;
            ____result.Reserved5 = __Reserved5__;
            ____result.Reserved6 = __Reserved6__;

            ____result.ID = __ID__;
            return ____result;
        }
    }


    public sealed class NotificationsFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.Notifications>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public NotificationsFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "CabinetsID", 0},
                { "FieldID", 1},
                { "UserID", 2},
                { "NotificationTime", 3},
                { "UpdateDate", 4},
                { "Reserved1", 5},
                { "Reserved2", 6},
                { "Reserved3", 7},
                { "Reserved4", 8},
                { "Reserved5", 9},
                { "Reserved6", 10},
                { "ID", 11},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CabinetsID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("FieldID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("UserID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("NotificationTime"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("UpdateDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved1"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved2"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved3"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved4"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved5"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved6"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.Notifications value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteMapHeader(ref bytes, offset, 12);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.CabinetsID);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.FieldID);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.UserID);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.NotificationTime, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.UpdateDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved1, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved2, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[7]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved3, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[8]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved4, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[9]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved5, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[10]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved6, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[11]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.Notifications Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __CabinetsID__ = default(int);
            var __FieldID__ = default(int);
            var __UserID__ = default(int);
            var __NotificationTime__ = default(global::System.DateTime?);
            var __UpdateDate__ = default(global::System.DateTime?);
            var __Reserved1__ = default(string);
            var __Reserved2__ = default(string);
            var __Reserved3__ = default(string);
            var __Reserved4__ = default(string);
            var __Reserved5__ = default(string);
            var __Reserved6__ = default(string);
            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __CabinetsID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 1:
                        __FieldID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 2:
                        __UserID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 3:
                        __NotificationTime__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 4:
                        __UpdateDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 5:
                        __Reserved1__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 6:
                        __Reserved2__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 7:
                        __Reserved3__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 8:
                        __Reserved4__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 9:
                        __Reserved5__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 10:
                        __Reserved6__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 11:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.Notifications();
            ____result.CabinetsID = __CabinetsID__;
            ____result.FieldID = __FieldID__;
            ____result.UserID = __UserID__;
            ____result.NotificationTime = __NotificationTime__;
            ____result.UpdateDate = __UpdateDate__;
            ____result.Reserved1 = __Reserved1__;
            ____result.Reserved2 = __Reserved2__;
            ____result.Reserved3 = __Reserved3__;
            ____result.Reserved4 = __Reserved4__;
            ____result.Reserved5 = __Reserved5__;
            ____result.Reserved6 = __Reserved6__;

            ____result.ID = __ID__;
            return ____result;
        }
    }



    public sealed class ProvinceFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.Province>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public ProvinceFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "CreateDate", 0},
                { "ProvinceName", 1},
                { "Reserved1", 2},
                { "Reserved2", 3},
                { "ID", 4},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CreateDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ProvinceName"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved1"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved2"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.Province value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteMapHeader(ref bytes, offset, 5);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.CreateDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.ProvinceName, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved1, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved2, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.Province Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __CreateDate__ = default(global::System.DateTime?);
            var __ProvinceName__ = default(string);
            var __Reserved1__ = default(string);
            var __Reserved2__ = default(string);
            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __CreateDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 1:
                        __ProvinceName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __Reserved1__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __Reserved2__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 4:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.Province();
            ____result.CreateDate = __CreateDate__;
            ____result.ProvinceName = __ProvinceName__;
            ____result.Reserved1 = __Reserved1__;
            ____result.Reserved2 = __Reserved2__;
            ____result.ID = __ID__;
            return ____result;
        }
    }


    public sealed class WaterFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SQL.SQLTables.Water>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public WaterFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "FieldID", 0},
                { "WaterMinLevel", 1},
                { "WaterMaxLevel", 2},
                { "WaterLevelValue", 3},
                { "UpdateDate", 4},
                { "Reserved1", 5},
                { "Reserved2", 6},
                { "Reserved3", 7},
                { "Reserved4", 8},
                { "Reserved5", 9},
                { "Reserved6", 10},
                { "ID", 11},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("FieldID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("WaterMinLevel"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("WaterMaxLevel"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("WaterLevelValue"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("UpdateDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved1"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved2"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved3"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved4"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved5"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Reserved6"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("ID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SQL.SQLTables.Water value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteMapHeader(ref bytes, offset, 12);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.FieldID);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.WaterMinLevel);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.WaterMaxLevel);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.WaterLevelValue);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Serialize(ref bytes, offset, value.UpdateDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved1, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved2, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[7]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved3, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[8]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved4, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[9]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved5, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[10]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Reserved6, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[11]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ID);
            return offset - startOffset;
        }

        public global::BomNuoc.SQL.SQLTables.Water Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __FieldID__ = default(int);
            var __WaterMinLevel__ = default(int);
            var __WaterMaxLevel__ = default(int);
            var __WaterLevelValue__ = default(int);
            var __UpdateDate__ = default(global::System.DateTime?);
            var __Reserved1__ = default(string);
            var __Reserved2__ = default(string);
            var __Reserved3__ = default(string);
            var __Reserved4__ = default(string);
            var __Reserved5__ = default(string);
            var __Reserved6__ = default(string);
            var __ID__ = default(int);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __FieldID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 1:
                        __WaterMinLevel__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 2:
                        __WaterMaxLevel__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 3:
                        __WaterLevelValue__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 4:
                        __UpdateDate__ = UTCToLocalTime.ConvertUTCToLocalTime(formatterResolver.GetFormatterWithVerify<global::System.DateTime?>().Deserialize(bytes, offset, formatterResolver, out readSize));
                        break;
                    case 5:
                        __Reserved1__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 6:
                        __Reserved2__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 7:
                        __Reserved3__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 8:
                        __Reserved4__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 9:
                        __Reserved5__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 10:
                        __Reserved6__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 11:
                        __ID__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SQL.SQLTables.Water();
            ____result.FieldID = __FieldID__;
            ____result.WaterMinLevel = __WaterMinLevel__;
            ____result.WaterMaxLevel = __WaterMaxLevel__;
            ____result.WaterLevelValue = __WaterLevelValue__;
            ____result.UpdateDate = __UpdateDate__;
            ____result.Reserved1 = __Reserved1__;
            ____result.Reserved2 = __Reserved2__;
            ____result.Reserved3 = __Reserved3__;
            ____result.Reserved4 = __Reserved4__;
            ____result.Reserved5 = __Reserved5__;
            ____result.Reserved6 = __Reserved6__;

            ____result.ID = __ID__;
            return ____result;
        }
    }


    

}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

namespace BomNuoc.Formatters.BomNuoc.SSL
{
    using System;
    using MessagePack;


    public sealed class SSLCommandsFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommandsFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
            };

            this.____stringByteKeys = new byte[][]
            {

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 0);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;


            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands();
            return ____result;
        }
    }


    public sealed class SSLCommands_SSLCommandBaseFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.SSLCommandBase>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_SSLCommandBaseFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "token", 0},
                { "AppID", 1},
                { "RequestID", 2},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.SSLCommandBase value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 3);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.SSLCommandBase Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.SSLCommandBase();
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }


    public sealed class SSLCommands_AcknowledgementFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.Acknowledgement>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_AcknowledgementFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "token", 0},
                { "AppID", 1},
                { "RequestID", 2},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.Acknowledgement value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 3);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.Acknowledgement Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.Acknowledgement();
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }


    public sealed class SSLCommands_TestMessageFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.TestMessage>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_TestMessageFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "message", 0},
                { "token", 1},
                { "AppID", 2},
                { "RequestID", 3},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("message"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.TestMessage value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 4);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.message, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.TestMessage Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __message__ = default(string);
            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __message__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.TestMessage();
            ____result.message = __message__;
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }


    public sealed class SSLCommands_LoginFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.Login>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_LoginFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "UserName", 0},
                { "Password", 1},
                { "token", 2},
                { "AppID", 3},
                { "RequestID", 4},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("UserName"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Password"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.Login value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 5);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.UserName, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Password, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.Login Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __UserName__ = default(string);
            var __Password__ = default(string);
            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __UserName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __Password__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 4:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.Login();
            ____result.UserName = __UserName__;
            ____result.Password = __Password__;
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }


    public sealed class SSLCommands_UpdateTokenFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.UpdateToken>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_UpdateTokenFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "token", 0},
                { "AppID", 1},
                { "RequestID", 2},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.UpdateToken value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 3);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.UpdateToken Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.UpdateToken();
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }


    public sealed class SSLCommands_NeedReloginFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.NeedRelogin>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_NeedReloginFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "token", 0},
                { "AppID", 1},
                { "RequestID", 2},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.NeedRelogin value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 3);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.NeedRelogin Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.NeedRelogin();
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }


    public sealed class SSLCommands_SQLExecuteReaderFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.SQLExecuteReader>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_SQLExecuteReaderFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "TableName", 0},
                { "Command", 1},
                { "DataJson", 2},
                { "SuccessExecute", 3},
                { "Where", 4},
                { "LastInsertId", 5},
                { "token", 6},
                { "AppID", 7},
                { "RequestID", 8},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TableName"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Command"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("DataJson"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("SuccessExecute"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Where"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("LastInsertId"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.SQLExecuteReader value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 9);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.TableName, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<global::BomNuoc.SSL.SSLCommands.SQLExecuteReader.SQLCommands>().Serialize(ref bytes, offset, value.Command, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.DataJson, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.SuccessExecute);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Where, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += MessagePackBinary.WriteInt64(ref bytes, offset, value.LastInsertId);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[7]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[8]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.SQLExecuteReader Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __TableName__ = default(string);
            var __Command__ = default(global::BomNuoc.SSL.SSLCommands.SQLExecuteReader.SQLCommands);
            var __DataJson__ = default(string);
            var __SuccessExecute__ = default(bool);
            var __Where__ = default(string);
            var __LastInsertId__ = default(long);
            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __TableName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __Command__ = formatterResolver.GetFormatterWithVerify<global::BomNuoc.SSL.SSLCommands.SQLExecuteReader.SQLCommands>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __DataJson__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __SuccessExecute__ = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
                        break;
                    case 4:
                        __Where__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 5:
                        __LastInsertId__ = MessagePackBinary.ReadInt64(bytes, offset, out readSize);
                        break;
                    case 6:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 7:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 8:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.SQLExecuteReader();
            ____result.TableName = __TableName__;
            ____result.Command = __Command__;
            ____result.DataJson = __DataJson__;
            ____result.SuccessExecute = __SuccessExecute__;
            ____result.Where = __Where__;
            ____result.LastInsertId = __LastInsertId__;
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }


    public sealed class SSLCommands_SQLExecuteReaderBinaryFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_SQLExecuteReaderBinaryFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "TableName", 0},
                { "Command", 1},
                { "DataJson", 2},
                { "DataBinary", 3},
                { "SuccessExecute", 4},
                { "Where", 5},
                { "LastInsertId", 6},
                { "token", 7},
                { "AppID", 8},
                { "RequestID", 9},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("TableName"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Command"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("DataJson"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("DataBinary"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("SuccessExecute"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("Where"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("LastInsertId"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 10);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.TableName, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary.SQLCommands>().Serialize(ref bytes, offset, value.Command, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.DataJson, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += formatterResolver.GetFormatterWithVerify<byte[]>().Serialize(ref bytes, offset, value.DataBinary, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.SuccessExecute);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Where, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += MessagePackBinary.WriteInt64(ref bytes, offset, value.LastInsertId);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[7]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[8]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[9]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __TableName__ = default(string);
            var __Command__ = default(global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary.SQLCommands);
            var __DataJson__ = default(string);
            var __DataBinary__ = default(byte[]);
            var __SuccessExecute__ = default(bool);
            var __Where__ = default(string);
            var __LastInsertId__ = default(long);
            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __TableName__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __Command__ = formatterResolver.GetFormatterWithVerify<global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary.SQLCommands>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __DataJson__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __DataBinary__ = formatterResolver.GetFormatterWithVerify<byte[]>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 4:
                        __SuccessExecute__ = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
                        break;
                    case 5:
                        __Where__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 6:
                        __LastInsertId__ = MessagePackBinary.ReadInt64(bytes, offset, out readSize);
                        break;
                    case 7:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 8:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 9:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.SQLExecuteReaderBinary();
            ____result.TableName = __TableName__;
            ____result.Command = __Command__;
            ____result.DataJson = __DataJson__;
            ____result.DataBinary = __DataBinary__;
            ____result.SuccessExecute = __SuccessExecute__;
            ____result.Where = __Where__;
            ____result.LastInsertId = __LastInsertId__;
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }


    public sealed class SSLCommands_ErrorMessageFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.ErrorMessage>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_ErrorMessageFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "message", 0},
                { "token", 1},
                { "AppID", 2},
                { "RequestID", 3},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("message"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.ErrorMessage value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 4);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.message, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.ErrorMessage Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __message__ = default(string);
            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __message__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.ErrorMessage();
            ____result.message = __message__;
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }

    
    public sealed class SSLCommands_UpdateDataFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.UpdateData>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_UpdateDataFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "CallFromJson", 0},
                { "CallToJson", 1},
                { "CabinetsJson", 2},
                { "DataType", 3},
                { "DataJson", 4},
                { "token", 5},
                { "AppID", 6},
                { "RequestID", 7},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CallFromJson"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CallToJson"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CabinetsJson"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("DataType"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("DataJson"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.UpdateData value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 8);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.CallFromJson, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.CallToJson, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.CabinetsJson, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.DataType);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.DataJson, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[7]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.UpdateData Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __CallFromJson__ = default(string);
            var __CallToJson__ = default(string);
            var __CabinetsJson__ = default(string);
            var __DataType__ = default(int);
            var __DataJson__ = default(string);
            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __CallFromJson__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __CallToJson__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __CabinetsJson__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __DataType__ = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
                        break;
                    case 4:
                        __DataJson__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 5:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 6:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 7:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.UpdateData();
            ____result.CallFromJson = __CallFromJson__;
            ____result.CallToJson = __CallToJson__;
            ____result.CabinetsJson = __CabinetsJson__;
            ____result.DataType = __DataType__;
            ____result.DataJson = __DataJson__;
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }

                  
              

    public sealed class SSLCommands_RequestCabinetsOnOffDataFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.RequestCabinetsOnOffData>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_RequestCabinetsOnOffDataFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "CabinetsJson", 0},
                { "IsStart", 1},
                { "IsError", 2},
                { "reserved", 3},
                { "token", 4},
                { "AppID", 5},
                { "RequestID", 6},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("CabinetsJson"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("IsStart"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("IsError"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("reserved"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.RequestCabinetsOnOffData value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 7);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.CabinetsJson, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.IsStart);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.IsError);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.reserved, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.RequestCabinetsOnOffData Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __CabinetsJson__ = default(string);
            var __IsStart__ = default(bool);
            var __IsError__ = default(bool);
            var __reserved__ = default(string);
            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __CabinetsJson__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __IsStart__ = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
                        break;
                    case 2:
                        __IsError__ = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
                        break;
                    case 3:
                        __reserved__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 4:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 5:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 6:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.RequestCabinetsOnOffData();
            ____result.CabinetsJson = __CabinetsJson__;
            ____result.IsStart = __IsStart__;
            ____result.IsError = __IsError__;
            ____result.reserved = __reserved__;
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }

    public sealed class SSLCommands_SendCabinetsOnOffDataFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::BomNuoc.SSL.SSLCommands.SendCabinetsOnOffData>
    {

        readonly global::MessagePack.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SSLCommands_SendCabinetsOnOffDataFormatter()
        {
            this.____keyMapping = new global::MessagePack.Internal.AutomataDictionary()
            {
                { "FromCabinetsJson", 0},
                { "SendDate", 1},
                { "SendDataJson", 2},
                { "reserved", 3},
                { "token", 4},
                { "AppID", 5},
                { "RequestID", 6},
            };

            this.____stringByteKeys = new byte[][]
            {
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("FromCabinetsJson"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("SendDate"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("SendDataJson"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("reserved"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("token"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("AppID"),
                global::MessagePack.MessagePackBinary.GetEncodedStringBytes("RequestID"),

            };
        }


        public int Serialize(ref byte[] bytes, int offset, global::BomNuoc.SSL.SSLCommands.SendCabinetsOnOffData value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }

            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 7);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[0]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.FromCabinetsJson, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[1]);
            offset += formatterResolver.GetFormatterWithVerify<global::System.DateTime>().Serialize(ref bytes, offset, value.SendDate, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[2]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.SendDataJson, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[3]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.reserved, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[4]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.token, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[5]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.AppID, formatterResolver);
            offset += global::MessagePack.MessagePackBinary.WriteRaw(ref bytes, offset, this.____stringByteKeys[6]);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.RequestID, formatterResolver);
            return offset - startOffset;
        }

        public global::BomNuoc.SSL.SSLCommands.SendCabinetsOnOffData Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
            offset += readSize;

            var __FromCabinetsJson__ = default(string);
            var __SendDate__ = default(global::System.DateTime);
            var __SendDataJson__ = default(string);
            var __reserved__ = default(string);
            var __token__ = default(string);
            var __AppID__ = default(string);
            var __RequestID__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var stringKey = global::MessagePack.MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
                offset += readSize;
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __FromCabinetsJson__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 1:
                        __SendDate__ = formatterResolver.GetFormatterWithVerify<global::System.DateTime>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 2:
                        __SendDataJson__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 3:
                        __reserved__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 4:
                        __token__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 5:
                        __AppID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    case 6:
                        __RequestID__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }

                NEXT_LOOP:
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::BomNuoc.SSL.SSLCommands.SendCabinetsOnOffData();
            ____result.FromCabinetsJson = __FromCabinetsJson__;
            ____result.SendDate = __SendDate__;
            ____result.SendDataJson = __SendDataJson__;
            ____result.reserved = __reserved__;
            ____result.token = __token__;
            ____result.AppID = __AppID__;
            ____result.RequestID = __RequestID__;
            return ____result;
        }
    }


    
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
