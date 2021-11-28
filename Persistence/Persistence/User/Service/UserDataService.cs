using AutoMapper;
using Persistence.User.Context;
using User.Domain.Interface.Persistence;
using CrossTools.ResultHandling.Interface;
using User.Domain.Interface.Model;
using CrossTools.ResultHandling.Implementation;
using CrossTools.ResultHandling.Interface.Validation.Error;
using System.Data.Entity;
using CrossTools.ConnectionStringFactory;

namespace Persistence.User.Service
{
    public class UserDataService : IUserDataService
    {
        private readonly IConnectionStringFactory _connectionStringFactory;
        private readonly IMapper _mapper;

        public UserDataService(IConnectionStringFactory connectionStringFactory, IMapper mapper)
        {
            _connectionStringFactory = connectionStringFactory ?? throw new ArgumentNullException(nameof(connectionStringFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IUserModel> GetAsync(int id)
        {
            using (var context = new UserContext(_connectionStringFactory))
            {
                var entity = await context.User.FirstOrDefaultAsync(x => x.ID == id);
                return _mapper.Map<Model.User, IUserModel>(entity);
            }
        }

        public async Task<IErrorResult<int?, IExtendedError<IUserModel>>> CreateAsync(IUserModel userModel)
        {
            using (var context = new UserContext(_connectionStringFactory))
            {
                var notification = new Notification<IExtendedError<Model.User>>();

                var entity = await context.User.FirstOrDefaultAsync(x => x.ID == userModel.ID);
                if (entity != null)
                {
                    notification.Add(new ExtendedError<Model.User>(new AlreadyExists()));
                    return ErrorResult.CreateResult<int?, Model.User, IUserModel>(null, notification, _mapper);
                }

                var user = _mapper.Map<Model.User>(userModel);

                context.User.Add(user);
                await context.SaveChangesAsync();

                return ErrorResult.CreateResult<int?, Model.User, IUserModel>(user.ID, notification, _mapper);
            }
        }

        public async Task<INotification<IExtendedError<IUserModel>>> UpdateAsync(IUserModel userModel)
        {
            var notification = new Notification<IExtendedError<IUserModel>>();

            using (var context = new UserContext(_connectionStringFactory))
            {
                var User = context.User.FirstOrDefault(a => a.ID == userModel.ID);

                if (User is null)
                {
                    notification.Add(new ExtendedError<IUserModel>(new NotFound(), nameof(IUserModel)));
                    return notification;
                }

                _mapper.Map(userModel, User);

                await context.SaveChangesAsync();
            }

            return notification;
        }

        public async Task<IErrorResult<IExtendedError<IUserModel>>> DeleteAsync(int id)
        {
            using (var context = new UserContext(_connectionStringFactory))
            {
                var notification = new Notification<IExtendedError<Model.User>>();
                var entity = await context.User.FirstOrDefaultAsync(x => x.ID == id);

                if (entity == null)
                {
                    notification.Add(new ExtendedError<Model.User>(new NotFound()));
                    return ErrorResult.CreateResult<Model.User, IUserModel>(notification, _mapper);
                }

                context.User.Remove(entity);
                await context.SaveChangesAsync();

                return ErrorResult.CreateResult<Model.User, IUserModel>(notification, _mapper);
            }
        }
    }
}