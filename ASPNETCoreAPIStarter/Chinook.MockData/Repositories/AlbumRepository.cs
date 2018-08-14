﻿using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.MockData.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public void Dispose()
        {
        }

        public async Task<List<Album>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            IList<Album> list = new List<Album>();

            var album = new Album
            {
                AlbumId = 1,
                ArtistId = 1,
                Title = "Hellow World"
            };
            list.Add(album);

            return list.ToList();
        }

        public async Task<Album> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var album = new Album
            {
                AlbumId = id,
                ArtistId = 1,
                Title = "Hello World"
            };
            return album;
        }

        public async Task<Album> AddAsync(Album newAlbum, CancellationToken ct = default(CancellationToken))
        {
            newAlbum.AlbumId = 1;
            return newAlbum;
        }

        public async Task<bool> UpdateAsync(Album album, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return true;
        }

        public async Task<List<Album>> GetByArtistIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            IList<Album> list = new List<Album>();
            var newisd = new Album
            {
                Title = "hello World",
                ArtistId = 1,
                AlbumId = 1
            };
            list.Add(newisd);
            return list.ToList();
        }
    }
}
