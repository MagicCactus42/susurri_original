using Susurri.Core.Abstractions;
using Susurri.Core.DTO;

namespace Susurri.Core.Queries;

public abstract class GetUsers : IQuery<IEnumerable<UserDto>>;
