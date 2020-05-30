﻿using BlogR.Core.Data.Entities;
using BlogR.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogR.Data.EF
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context)
            : base(context)
        {
        }
    }
}
