/*////////////////////////////////////////////////////////////////////////
/* Copyright (c)
/* Mohawk College, 135 Fennell Ave W, Hamilton, Ontario, Canada L9C 0E5
/* Game Design (374): GAME 10033 Game Development Foundations
/* Source: https://github.com/MohawkRaphaelT/game10003-2d-game-template
/*////////////////////////////////////////////////////////////////////////

using System;

namespace GeneratorTools
{
    /// <summary>
    ///     Attribute signaling the documentation generator not to include item in output.
    /// </summary>
    [OmitFromDocumentation]
    [AttributeUsage(AttributeTargets.All)]
    public sealed class OmitFromDocumentationAttribute : Attribute
    {
    }
}
