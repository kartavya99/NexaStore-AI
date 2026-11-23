# NexaStore

**Computing for Developers, Creators & AI Builders**

NexaStore is a personal learning project: a .NET 10 modular-monolith
e-commerce application with a React storefront, built step by step to
practice production-style backend development and to explore how AI features
fit into a real application. It currently includes a complete commerce API,
a responsive storefront, and Nexa AI, a local shopping assistant that answers
from live catalog and inventory data.

## Nexa AI assistant

- Runs locally through Ollama (default model `qwen3.5:4b`) using
  Microsoft.Extensions.AI
- Streams replies to the storefront over Server-Sent Events, with cancellation
- Concise, balanced, and detailed response styles
- Read-only tools for product search, product details, categories, and
  inventory checks
- Guardrails: validated requests, a system prompt that treats chat messages
  and tool output as untrusted data, and a limit on tool-call rounds
- No access to carts, orders, customers, or policies yet

## Backend status

- .NET 10 ASP.NET Core REST API
- EF Core 10 with PostgreSQL
- Structured product search
- Transactional cart-to-order workflow
- Optimistic inventory/order concurrency through PostgreSQL `xmin`
- FluentValidation and ProblemDetails
- Serilog structured logging
- OpenAPI and Swagger UI
- Liveness, readiness, and combined health checks
- Unit, persistence, workflow, and HTTP integration tests

## Frontend status

- React 19 and TypeScript 6 on Vite 8
- Tailwind CSS 4 design system and responsive premium storefront
- Product discovery, filters, product details, cart, checkout, and order history
- TanStack Query server-state management and typed Axios API boundary
- React Router route architecture with loading, error, empty, and 404 states
- Vitest and Testing Library coverage

## Learning focus

The project is a hands-on way to work with:

- Layered architecture across Domain, Application, Infrastructure, and API
- Transactional workflows and concurrency with EF Core and PostgreSQL
- Streaming APIs with Server-Sent Events
- LLM tool calling and prompt design with Microsoft.Extensions.AI
- Integration testing with `WebApplicationFactory`

## Roadmap

- Retrieval-augmented generation (RAG) over the `knowledge-base/` documents,
  with vector search
- Cart and order support in the assistant
- MCP server and agent workflows

## Run the complete stack

Create a `.env` file in the repository root:

```env
POSTGRES_DB=nexastore
POSTGRES_USER=nexastore
POSTGRES_PASSWORD=<choose-a-password>
# Optional, defaults to qwen3.5:4b
OLLAMA_MODEL=qwen3.5:4b
```

Then start everything:

```powershell
docker compose up -d --build
```

The first start downloads the Ollama model, which can take several minutes.

- Storefront: `http://localhost:5173`
- API and Swagger: `http://localhost:5175/swagger`
- PostgreSQL: `localhost:5432`
- Ollama: `http://localhost:11434`

## Repository

```text
backend/        .NET solution projects
tests/          Unit and integration tests
frontend/       React storefront
knowledge-base/ Documents for the planned RAG phase
```
