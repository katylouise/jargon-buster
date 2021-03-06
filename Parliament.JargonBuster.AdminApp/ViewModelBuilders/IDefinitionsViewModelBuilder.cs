﻿using AdminApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.ViewModelBuilders
{
    public interface IDefinitionsViewModelBuilder
    {
        DefinitionsViewModel Build();

        DefinitionViewModel BuildDefinitionViewModelFromId(int id);
    }
}
