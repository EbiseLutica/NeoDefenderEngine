using System;

namespace NeoDefenderEngine
{
    static class Entry
    {
        static int Main(string[] args) => new Engine(640, 480, "Defender Engine").Run();
    }
}
