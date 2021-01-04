/*
 * using Orleans;
using Orleans.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrainImplementation
{
    class QuestGrain : Grain
    {
        private StackUnderflowContext _dbContext;
        private QuestGrain state;

        public QuestGrain(StackUnderflowContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task OnActivateAsync()
        {
            var key = this.GetPrimaryKey();
            Post post = new Post();

            var expPostId = from postId in post.PostId.ToString()
                            where postId.Equals(key.ToString())
                            select postId;

            var expParentPostId = from parentPostId in post.ParentPostId.ToString()
                                  where parentPostId.Equals(key.ToString())
                                  select parentPostId;


            // subscribe to replys stream
            var streamProvider = GetStreamProvider("SMSProvider");
            var stream = streamProvider.GetStream<string>(Guid.Empty, "LETTER");
            await stream.SubscribeAsync((IAsyncObserver<string>)this);

            // return base.OnActivateAsync();
        }
    }
}
*/