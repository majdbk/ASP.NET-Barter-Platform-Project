using System;

namespace tntroc.Data.Infrastructure
{
   public interface IDatabaseFactory : IDisposable
    {
        // instancié l'objet Context
        GOContext DataContext { get; }
    }

    //1er principe
    //Séparation des Conceptes (SoC)

    // 2eme principe
    // Principe de responsabilité unique (SRP)
    //- chaque objet doit avoir une responsabilité unique,
    //et que tous ses services doit être étroitement aligné avec cette responsabilité.
}
