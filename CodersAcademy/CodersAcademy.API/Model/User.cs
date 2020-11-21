using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.Model
{
    public class User
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public IList<UserFavoriteMusic> FavoriteMusics { get; set; }

        public void AddFavoriteMusic(Music music)
        {
            this.FavoriteMusics.Add(new UserFavoriteMusic()
            {
                Music = music,
                MusicId = music.Id,
                User = this,
                UserId = this.Id
            });
        }

        public void RemoveFavoriteMusic(Music music)
        {
            var favmuisc = this.FavoriteMusics.Where(x => x.MusicId == music.Id).FirstOrDefault();

            if (favmuisc == null)
                throw new Exception("Music não encontrada na lista de favoritos");

            this.FavoriteMusics.Remove(favmuisc);
        }
    }
}
