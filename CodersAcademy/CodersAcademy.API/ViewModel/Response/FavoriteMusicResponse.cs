using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.ViewModel.Response
{
    public class FavoriteMusicResponse
    {
        public Guid Id { get; set; }
        public Guid MusicId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string AlbumName { get; set; }
        public string Band { get; set; }
        public string Backdrop { get; set; }
        public string AlbumId { get; set; }
    }
}
