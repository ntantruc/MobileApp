using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNuoc.ViewModels
{
    public class calc : ViewModelBase
    {
        private static calc instance = new calc();
        public static calc i { get { return instance; } }

        public void Refresh()
        {
            var properties = Enumerable.Range(0, 64).Select(x => "c" + x.ToString()).ToList();
            properties.Add("conv");
            RaisePropertyChanged(properties.ToArray());
        }

        public double conv { get; set; }
        public double c0 { get { return Resource.Size.calc(0); } set { } }
        public double c1 { get { return Resource.Size.calc(1); } set { } }
        public double c2 { get { return Resource.Size.calc(2); } set { } }
        public double c3 { get { return Resource.Size.calc(3); } set { } }
        public double c4 { get { return Resource.Size.calc(4); } set { } }
        public double c5 { get { return Resource.Size.calc(5); } set { } }
        public double c6 { get { return Resource.Size.calc(6); } set { } }
        public double c7 { get { return Resource.Size.calc(7); } set { } }
        public double c8 { get { return Resource.Size.calc(8); } set { } }
        public double c9 { get { return Resource.Size.calc(9); } set { } }
        public double c10 { get { return Resource.Size.calc(10); } set { } }
        public double c11 { get { return Resource.Size.calc(11); } set { } }
        public double c12 { get { return Resource.Size.calc(12); } set { } }
        public double c13 { get { return Resource.Size.calc(13); } set { } }
        public double c14 { get { return Resource.Size.calc(14); } set { } }
        public double c15 { get { return Resource.Size.calc(15); } set { } }
        public double c16 { get { return Resource.Size.calc(16); } set { } }
        public double c17 { get { return Resource.Size.calc(17); } set { } }
        public double c18 { get { return Resource.Size.calc(18); } set { } }
        public double c19 { get { return Resource.Size.calc(19); } set { } }
        public double c20 { get { return Resource.Size.calc(20); } set { } }
        public double c21 { get { return Resource.Size.calc(21); } set { } }
        public double c22 { get { return Resource.Size.calc(22); } set { } }
        public double c23 { get { return Resource.Size.calc(23); } set { } }
        public double c24 { get { return Resource.Size.calc(24); } set { } }
        public double c25 { get { return Resource.Size.calc(25); } set { } }
        public double c26 { get { return Resource.Size.calc(26); } set { } }
        public double c27 { get { return Resource.Size.calc(27); } set { } }
        public double c28 { get { return Resource.Size.calc(28); } set { } }
        public double c29 { get { return Resource.Size.calc(29); } set { } }
        public double c30 { get { return Resource.Size.calc(30); } set { } }
        public double c31 { get { return Resource.Size.calc(31); } set { } }
        public double c32 { get { return Resource.Size.calc(32); } set { } }
        public double c33 { get { return Resource.Size.calc(33); } set { } }
        public double c34 { get { return Resource.Size.calc(34); } set { } }
        public double c35 { get { return Resource.Size.calc(35); } set { } }
        public double c36 { get { return Resource.Size.calc(36); } set { } }
        public double c37 { get { return Resource.Size.calc(37); } set { } }
        public double c38 { get { return Resource.Size.calc(38); } set { } }
        public double c39 { get { return Resource.Size.calc(39); } set { } }
        public double c40 { get { return Resource.Size.calc(40); } set { } }
        public double c41 { get { return Resource.Size.calc(41); } set { } }
        public double c42 { get { return Resource.Size.calc(42); } set { } }
        public double c43 { get { return Resource.Size.calc(43); } set { } }
        public double c44 { get { return Resource.Size.calc(44); } set { } }
        public double c45 { get { return Resource.Size.calc(45); } set { } }
        public double c46 { get { return Resource.Size.calc(46); } set { } }
        public double c47 { get { return Resource.Size.calc(47); } set { } }
        public double c48 { get { return Resource.Size.calc(48); } set { } }
        public double c49 { get { return Resource.Size.calc(49); } set { } }
        public double c50 { get { return Resource.Size.calc(50); } set { } }
        public double c51 { get { return Resource.Size.calc(51); } set { } }
        public double c52 { get { return Resource.Size.calc(52); } set { } }
        public double c53 { get { return Resource.Size.calc(53); } set { } }
        public double c54 { get { return Resource.Size.calc(54); } set { } }
        public double c55 { get { return Resource.Size.calc(55); } set { } }
        public double c56 { get { return Resource.Size.calc(56); } set { } }
        public double c57 { get { return Resource.Size.calc(57); } set { } }
        public double c58 { get { return Resource.Size.calc(58); } set { } }
        public double c59 { get { return Resource.Size.calc(59); } set { } }
        public double c60 { get { return Resource.Size.calc(60); } set { } }
        public double c61 { get { return Resource.Size.calc(61); } set { } }
        public double c62 { get { return Resource.Size.calc(62); } set { } }
        public double c63 { get { return Resource.Size.calc(63); } set { } }
        public double c64 { get { return Resource.Size.calc(64); } set { } }
    }
}
