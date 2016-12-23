using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuyz.Communication.Protocol
{
    public interface IProtocol
    {
        byte[] getDetectPLCCmd(ref int thresHold);

        byte[] getSetPLCRunCmd(ref int thresHold);
        byte[] getSetPLCStopCmd(ref int thresHold);

        byte[] getReadDataByBitCmd(UInt32 baseAddr, UInt32 offset, UInt32 numToRead, ref int thresHold);
        byte[] getWriteDataByBitCmd(UInt32 baseAddr, UInt32 offset, bool[] dataArr, ref int thresHold);

        byte[] getReadDataByWordCmd(UInt32 baseAddr, UInt32 numToRead, ref int thresHold);
        byte[] getWriteDataByWordCmd(UInt32 baseAddr, UInt32[] dataArr, ref int thresHold);

        byte[] getReadRelayByBitCmd(UInt32 baseAddr, UInt32 offset, UInt32 numToRead, ref int thresHold);
        byte[] getWriteRelayByBitCmd(UInt32 baseAddr, UInt32 offset, bool[] dataArr, ref int thresHold);

        byte[] getReadRelayByWordCmd(UInt32 baseAddr, UInt32 numToRead, ref int thresHold);
        byte[] getWriteRelayByWordCmd(UInt32 baseAddr, UInt32[] dataArr, ref int thresHold);

        RXMsg getRXDetails(byte[] receivedData, TXMsg sendMsg);

        string getRBSString();
    }
}
