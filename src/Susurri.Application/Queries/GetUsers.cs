using Susurri.Application.Abstractions;
using Susurri.Application.DTO;

namespace Susurri.Application.Queries;

public abstract class GetUsers : IQuery<IEnumerable<UserDto>>;
