﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;


namespace Repository
{
    public interface IWorkWithRepo
    {
        void AddItem(ArtWorkEntity item);
        List<ArtWorkEntity> GetAll();
        ArtWorkEntity GetItem(Guid id);
    }
}
