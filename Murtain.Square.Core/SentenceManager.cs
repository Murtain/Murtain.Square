using Murtain.Square.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murtain.Square.Core
{
    public class SentenceManager : ISentenceManager
    {
        private ISentenceRepository sentenceRepository;

        public SentenceManager(ISentenceRepository sentenceRepository)
        {
            this.sentenceRepository = sentenceRepository;
        }
        public async Task SentenceFavoriteAsync(Domain.Entities.Sentence sentence)
        {
            var entity = sentenceRepository.FirstOrDefault(x => x.FamousSaying == sentence.FamousSaying);

            if (entity == null)
            {
                await sentenceRepository.AddAsync(sentence);
                return;
            }

            await sentenceRepository.RemoveAsync(entity);
        }
    }
}
