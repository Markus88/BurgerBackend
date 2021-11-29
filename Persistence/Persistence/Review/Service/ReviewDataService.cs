using AutoMapper;
using CrossTools.ConnectionStringFactory;
using CrossTools.ResultHandling.Implementation;
using CrossTools.ResultHandling.Interface;
using CrossTools.ResultHandling.Interface.Validation.Error;
using Persistence.Review.Context;
using Review.Domain.Interface.Model;
using Review.Domain.Interface.Persistence;
using System.Data.Entity;

namespace Persistence.Review.Service
{
    public class ReviewDataService : IReviewDataService
    {
        private readonly IConnectionStringFactory _connectionStringFactory;
        private readonly IMapper _mapper;

        public ReviewDataService(IConnectionStringFactory connectionStringFactory, IMapper mapper)
        {
            _connectionStringFactory = connectionStringFactory ?? throw new ArgumentNullException(nameof(connectionStringFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IReviewModel> GetAsync(int id)
        {
            using (var context = new ReviewContext(_connectionStringFactory))
            {
                var entity = await context.Review.FirstOrDefaultAsync(x => x.ID == id);
                return _mapper.Map<Model.Review, IReviewModel>(entity);
            }
        }

        public async Task<IErrorResult<int?, IExtendedError<IReviewModel>>> CreateAsync(IReviewModel reviewModel)
        {
            using (var context = new ReviewContext(_connectionStringFactory))
            {
                var notification = new Notification<IExtendedError<Model.Review>>();

                var entity = await context.Review.FirstOrDefaultAsync(x => x.ID == reviewModel.ID);
                if (entity != null)
                {
                    notification.Add(new ExtendedError<Model.Review>(new AlreadyExists()));
                    return ErrorResult.CreateResult<int?, Model.Review, IReviewModel>(null, notification, _mapper);
                }

                var review = _mapper.Map<Model.Review>(reviewModel);

                context.Review.Add(review);
                await context.SaveChangesAsync();

                return ErrorResult.CreateResult<int?, Model.Review, IReviewModel>(review.ID, notification, _mapper);
            }
        }

        public async Task<IErrorResult<IExtendedError<IReviewModel>>> DeleteAsync(int id)
        {
            using (var context = new ReviewContext(_connectionStringFactory))
            {
                var notification = new Notification<IExtendedError<Model.Review>>();
                var entity = await context.Review.FirstOrDefaultAsync(x => x.ID == id);

                if (entity == null)
                {
                    notification.Add(new ExtendedError<Model.Review>(new NotFound()));
                    return ErrorResult.CreateResult<Model.Review, IReviewModel>(notification, _mapper);
                }

                context.Review.Remove(entity);
                await context.SaveChangesAsync();

                return ErrorResult.CreateResult<Model.Review, IReviewModel>(notification, _mapper);
            }
        }
    }
}
