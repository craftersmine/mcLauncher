using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace craftersmine.Launcher.Core
{
    public sealed class LauncherSettings
    {
        public const  string    LauncherTitle        = "Blockslife Launcher";      // Заголовок лаунчера. Не оставляйте пустым!
        public const  bool      IsLauncherTextsBlack = false;                      // True если у вас светлая тема лаунчера
        public static Color     NewsColor            = Color.LightGray;            // Цвет текста новостей. Ищите цвета на MSDN если у вас не Visual Studio
        public const  string    Domain               = "blockslife-server.hol.es";    // Домен сайта без http, https, :// и слеша в конце
        public const  string    ClientsFolder        = "Blockslife";               // Папка куда будут устанавливаться все клиенты. %AppData%\.Ваша_папка - Если у вас есть клиенты с версией 1.5.2, то изменяйте папку в Minecraft.class
        public const  string    Protocol             = "http";          // Протокол подключения. https если у вас есть SSL сертификат
        public const  string    DirOnServer          = "launcher";      // Папка лаунчера на сервере
        public const  string    Version              = "1.0";        // Версия лаунчера. Должна быть одинаковая и в configuration.php
        public const  string    UpdatePage           = "http://blockslife-server.hol.es";    // Страница обновления лаунчера
        public const  string    RegisterPage         = "http://blockslife-server.hol.es/index.php?do=register";      // Страница регистрации пользователя
        public const  string    LostPassPage         = "http://blockslife-server.hol.es/index.php?do=lostpassword";  // Страница восстановления пароля пользователя
    }
}
