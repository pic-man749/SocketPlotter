using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketPlotter {
    public static class Validation {

        public static bool TryPaesePortNum(TextBox tb) {
            return TryPaesePortNum(tb, out _);
        }

        public static bool TryPaesePortNum(TextBox tb, out int num) {
            bool ret = int.TryParse(tb.Text, out num);
            if(ret && 1 <= num && num <= 65535) {
                tb.ForeColor = System.Drawing.Color.Black;
                return ret;
            } else {
                tb.ForeColor = System.Drawing.Color.Red;
                return false;
            }
        }

        public static bool TryPaeseInt(TextBox tb, out int num) {
            bool ret = int.TryParse(tb.Text, out num);
            if(ret) {
                tb.ForeColor = System.Drawing.Color.Black;
            } else {
                tb.ForeColor = System.Drawing.Color.Red;
            }
            return ret;
        }

        public static bool TryPaeseDouble(TextBox tb, out double num) {
            bool ret = double.TryParse(tb.Text, out num);
            if(ret) {
                tb.ForeColor = System.Drawing.Color.Black;
            } else {
                tb.ForeColor = System.Drawing.Color.Red;
            }
            return ret;
        }
    }
}
