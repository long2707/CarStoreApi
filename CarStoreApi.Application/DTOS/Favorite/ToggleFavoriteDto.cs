﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.Favorite
{
    public class ToggleFavoriteDto
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
    }
}
