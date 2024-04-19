using Susurri.Client.Abstractions;
using Susurri.Client.DTO;

namespace Susurri.Client.Queries;

public abstract class GetUsers : IQuery<IEnumerable<UserDto>>;
