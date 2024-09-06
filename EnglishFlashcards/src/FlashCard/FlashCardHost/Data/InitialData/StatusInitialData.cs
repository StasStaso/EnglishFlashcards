using Microsoft.EntityFrameworkCore;

namespace FlashCard.Host.Data.InitialData
{
    public class StatusInitialData(ApplicationDbContext dbContext)
    {
        public async Task Handle()
        {
            if (!await dbContext.Status.AnyAsync())
            {
                var status = InitData();

                await dbContext.Status.AddRangeAsync(status);
                await dbContext.SaveChangesAsync();
            }
        }

        private List<StatusModel> InitData()
        {
            return new List<StatusModel>
            {
                new StatusModel
                {
                    StatusId = 1,
                    StatusName = "Unknown"
                },
                new StatusModel
                {
                    StatusId = 2,
                    StatusName = "Learning"
                },
                new StatusModel
                {
                    StatusId = 3,
                    StatusName = "Review"
                },
                new StatusModel
                {
                    StatusId = 4,
                    StatusName = "Known"
                }
            };
        }
    }
}
