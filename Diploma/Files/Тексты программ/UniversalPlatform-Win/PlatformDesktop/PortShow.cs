namespace PlatformDesktop
{

    public partial class MainWindow
    {
        private class PortShow
        {
            public PortShow(string name, string key, string COM)
            {
                this.name = name;
                this.key = key;
                this.COM = COM;
            }

            public string name { get; set; }
            public string key { get; set; }

            public string COM;
        }
    }

}

// TODO 
/* Ползунок мощности 
 * История команд 
 * GPS
 * Убрать режим разгона из мощности
 * стрелки пофиксить
 * модульность
 * дизайн дисплею 
 */