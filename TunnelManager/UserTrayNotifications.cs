using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoeriBekker.PuttyTunnelManager
{
    static class UserNotifications
    {

        private static UserNotificator userNotificator;

        public static UserNotificator getNotificator()
        {
            return userNotificator;
        }

        public static void init(UserNotificator notificator)
        {
            userNotificator = notificator;
        }
    }

    interface UserNotificator {
        void Notify(String title, String message);
    }
}
