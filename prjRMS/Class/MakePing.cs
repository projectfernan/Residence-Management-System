﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;    

namespace prjRMS
{
    class MakePing
    {
        public bool PingIp(string iP) 
        {
            try
            {
                Ping pingReq = new Ping();
                PingReply pingRep;

                pingRep = pingReq.Send(iP);

                if (pingRep.Status == IPStatus.Success)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}
