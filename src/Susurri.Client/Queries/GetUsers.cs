using Susurri.Client.Abstractions;
using Susurri.Client.DTO;

namespace Susurri.Client.Queries;

public class GetUsers : IQuery<IEnumerable<UserDto>>;
