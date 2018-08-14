﻿using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;

namespace Chinook.Data.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly RxzxContext _context;

        public ArtistRepository(RxzxContext context)
        {
            _context = context;
        }

        private async Task<bool> ArtistExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Artist>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.Artist.ToListAsync(ct);
        }

        public async Task<Artist> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Artist.FindAsync(id);
        }

        public async Task<Artist> AddAsync(Artist newArtist, CancellationToken ct = default(CancellationToken))
        {
            _context.Artist.Add(newArtist);
            await _context.SaveChangesAsync(ct);
            return newArtist;
        }

        public async Task<bool> UpdateAsync(Artist artist, CancellationToken ct = default(CancellationToken))
        {
            if (!await ArtistExists(artist.ArtistId, ct))
                return false;
            _context.Artist.Update(artist);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await ArtistExists(id, ct))
                return false;
            var toRemove = _context.Artist.Find(id);
            _context.Artist.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
