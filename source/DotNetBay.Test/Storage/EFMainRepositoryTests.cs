using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Data.EF;
using DotNetBay.Interfaces;


namespace DotNetBay.Test.Storage
{
    class EFMainRepositoryTests : MainRepositoryTestBase
    {
        protected override IRepositoryFactory CreateFactory()
        {
            return new EFMainRepositoryFactory();
        }
    }
}
