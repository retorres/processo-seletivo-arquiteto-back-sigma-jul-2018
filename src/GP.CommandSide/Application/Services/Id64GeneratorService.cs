using GP.CommandSide.Domain.Abstractions;
using IdGen;
using System;

namespace GP.CommandSide.Application.Services
{
    public class Id64GeneratorService : IIdGeneratorService<long>
    {

        private readonly IdGenerator _idGenerator;
        public Id64GeneratorService()
        {
            var epoch = new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var mc = new MaskConfig(45, 2, 16);

            _idGenerator = new IdGenerator(0, epoch, mc);
        }
        public long GenerateId() => _idGenerator.CreateId();
    }
}
