﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Chinook.Domain.Repositories;
using Chinook.Domain.Entities;
namespace Chinook.Data.Repositories
{
    public class PlaylistTrackRepository : IPlaylistTrackRepository
    {
        private readonly RxzxContext _context;

        public PlaylistTrackRepository(RxzxContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private async Task<bool> PlaylistTrackExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByPlaylistIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<PlaylistTrack>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.PlaylistTrack.ToListAsync(ct);
        }

        public async Task<List<PlaylistTrack>> GetByPlaylistIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.PlaylistTrack.Where(a => a.PlaylistId == id).ToListAsync(ct);
        }

        public async Task<List<PlaylistTrack>> GetByTrackIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.PlaylistTrack.Where(a => a.TrackId == id).ToListAsync(ct);
        }

        public async Task<PlaylistTrack> AddAsync(PlaylistTrack newPlaylistTrack, CancellationToken ct = default(CancellationToken))
        {
            _context.PlaylistTrack.Add(newPlaylistTrack);
            await _context.SaveChangesAsync(ct);
            return newPlaylistTrack;
        }

        public async Task<bool> UpdateAsync(PlaylistTrack playlistTrack, CancellationToken ct = default(CancellationToken))
        {
            if (!await PlaylistTrackExists(playlistTrack.PlaylistId, ct))
                return false;
            _context.PlaylistTrack.Update(playlistTrack);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await PlaylistTrackExists(id, ct))
                return false;
            var toRemove = _context.PlaylistTrack.Find(id);
            _context.PlaylistTrack.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
