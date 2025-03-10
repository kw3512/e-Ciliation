using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCiliation.Clients.Contracts;
public record CreateClientRequest(string clientName, string? description);
