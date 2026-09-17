using Microsoft.EntityFrameworkCore;

namespace CaseFlow.Infrastructure.Persistence;

public sealed class CaseFlowDbContext(DbContextOptions<CaseFlowDbContext> options)
    : DbContext(options);
