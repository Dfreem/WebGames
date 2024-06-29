using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGames.Shared.Models
{
    public class ChatUser
    {
        public string Name { get; set; } = default!;

        public string Avatar { get; set; } = "/images/default_avatar.png";

        public Color BubbleColor { get; set; }
    }
}
