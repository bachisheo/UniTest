using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Forms
{
   public  class Active_user
    {
        private static int id;
        private static Active_user istanc;
       
        public static void instance(int i)
        {
            if (istanc == null)
            {
                istanc = new Active_user();
                id = i;
            }

        }

        public static int get()
        {
            return id;
        }

    }


}
