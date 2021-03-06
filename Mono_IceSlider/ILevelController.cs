﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_IceSlider
{
    interface ILevelController
    {
        void ExecuteLevel();
        void SetActiveLevel(int id);
        void AddNewLevel(string filepath);
        void RemoveActiveLevel();
    }
}
