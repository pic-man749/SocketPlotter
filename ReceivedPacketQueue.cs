using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketPlotter {
    public static class ReceivedPacketQueue {

        private static ConcurrentQueue<ReceivedPacket> queue = new ConcurrentQueue<ReceivedPacket>();

        // init queue
        public static void Clear() {
            lock(queue) {
                ReceivedPacket tmp;
                while(queue.Count > 0) {
                    queue.TryDequeue(out tmp);
                }
            }
        }

        public static bool Add(ReceivedPacket recvPacket) {
            queue.Enqueue(recvPacket);
            return true;
        }

        public static bool Take(out ReceivedPacket recvPacket) {
            return queue.TryDequeue(out recvPacket);
        }
    }

    public struct ReceivedPacket {
        public Dictionary<string, string> data;
        public long recvTime;
    }
}
