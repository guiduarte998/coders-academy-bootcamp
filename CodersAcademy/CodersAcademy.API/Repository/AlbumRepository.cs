using CodersAcademy.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.Repository
{
    public class AlbumRepository
    {
        private MusicContext Context { get; init; }
        public AlbumRepository(MusicContext context)
        {
            this.Context = context;
        }
        public async Task<IList<Album>> GetAllAsync()
            => await this.Context.Albuns.Include(x => x.Musics).ToListAsync();

        //Aqui o task utiliza parametro pois estamos fazendo a busca do objeto
        public async Task<Album> GetAlbumByIdAsync(Guid id)
            => await this.Context.Albuns.Where(x => x.Id == id).FirstOrDefaultAsync();

        //Aqui não temos paramostros no task pois estamos deletando um objeto
        public async Task DeleteAsync(Album model)
        {
            this.Context.Remove(model);
            //Sempre ao fazer um delete temos que salvar a operação
            await this.Context.SaveChangesAsync();
        }

        public async Task CreateAsync(Album album)
        {
            await this.Context.Albuns.AddAsync(album);
            await this.Context.SaveChangesAsync();
        }

        public async Task<Music> GetMusicAsync(Guid musicId)
            => await this.Context.Music.Where(x => x.Id == musicId).FirstOrDefaultAsync();

    }
}
