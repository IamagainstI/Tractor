using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Routers.Command
{
    public static class Commands
    {
        public const string GET_TASK = nameof(GET_TASK);
        public const string GET_PROJECT = nameof(GET_PROJECT);
        public const string ADD_TASK = nameof(GET_TASK);
        public const string ADD_PROJECT = nameof(ADD_PROJECT);
        public const string EDITABLE_PROJECT = nameof(EDITABLE_PROJECT);
        public const string EDITABLE_TASK = nameof(EDITABLE_TASK);
        public const string CREATE_TEAM = nameof(CREATE_TEAM);
        public const string ADD_ENTITY_TO_TEAM = nameof(ADD_ENTITY_TO_TEAM);
        public const string SET_TASK_STATE = nameof(SET_TASK_STATE);
        public const string SET_PROJECT_STATE = nameof(SET_PROJECT_STATE);
        public const string DELETE_TASK = nameof(DELETE_TASK);
        public const string DELETE_PROJECT = nameof(DELETE_PROJECT);
    }
}
