﻿using Chinook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Domain.Repositories
{
    public interface ITrackRepository : IDisposable
    {
        Task<List<Track>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Track> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<Track>> GetByAlbumIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<Track>> GetByGenreIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<Track>> GetByMediaTypeIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Track> AddAsync(Track newTrack, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(Track track, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}
