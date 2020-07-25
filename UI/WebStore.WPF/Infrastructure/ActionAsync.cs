using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.WPF.Infrastructure
{
    internal delegate Task ActionAsync();

    internal delegate Task ActionAsync<T>(T arg);

    internal delegate Task ActionAsync<T1, T2>(T1 arg1, T2 arg2);

    internal delegate Task ActionAsync<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
}
