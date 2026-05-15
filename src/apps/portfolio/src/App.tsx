import React from 'react';

const spotlightFeatures = [
  {
    icon: 'C',
    title: 'Full C ABI Compatibility',
    description: 'Build native-level integrations with predictable low-level behavior.'
  },
  {
    icon: '◫',
    title: 'Module System',
    description: 'Organized, simple modules that keep projects easy to reason about.'
  },
  {
    icon: '±',
    title: 'Operator Overloading',
    description: 'Expressive syntax for domain-specific logic without sacrificing clarity.'
  }
];

const coreFeatures = [
  {
    icon: '⌘',
    title: 'Compile Time and Semantic Macros',
    description: 'Meta-programming tools that reduce boilerplate and improve correctness.'
  },
  {
    icon: '⟳',
    title: 'Runtime and compile-time reflection',
    description: 'Inspect and adapt behavior across runtime and compile time workflows.'
  },
  {
    icon: '✎',
    title: 'Gradual Contracts',
    description: 'Introduce contracts incrementally without forcing large rewrites.'
  },
  {
    icon: '‹›',
    title: 'Inline Assembly',
    description: 'Drop into low-level instructions where precise performance matters.'
  },
  {
    icon: '❕',
    title: 'Zero Overhead Errors',
    description: 'Error handling with zero-cost patterns and explicit intent.'
  },
  {
    icon: '✷',
    title: 'Debug with safety checks',
    description: 'Catch bugs earlier with clear runtime diagnostics and guards.'
  },
  {
    icon: '◩',
    title: 'Generic modules',
    description: 'Reusable abstractions with minimal syntax overhead.'
  },
  {
    icon: '▤',
    title: 'Detailed stacktraces',
    description: 'Debug faster with rich traces that pinpoint failures precisely.'
  }
];

const gettingStartedCards = [
  {
    icon: '⬇',
    title: 'Download',
    description: 'Install for Windows, macOS, and Linux with one-click setup.'
  },
  {
    icon: '🎓',
    title: 'Learn',
    description: 'Read practical guides and walkthroughs to ship quickly.'
  },
  {
    icon: '💬',
    title: 'Engage',
    description: 'Join the community and share feedback on your projects.'
  }
];

const App: React.FC = () => (
  <div className="c3-page">
    <header className="top-nav">
      <a className="brand" href="#hero">
        C3
      </a>
      <nav className="top-links" aria-label="Main navigation">
        <a href="#blog">Blog</a>
        <a href="#community">Discord</a>
        <a href="#code">GitHub</a>
      </nav>
      <div className="search">Search</div>
    </header>

    <main>
      <section id="hero" className="hero">
        <div className="hero-copy">
          <h1 className="hero-logo">C3</h1>
          <h2>
            The <span>C3</span> Programming Language
          </h2>
          <p>The ergonomic, safe and familiar evolution of C.</p>
          <div className="hero-actions">
            <button type="button" className="primary-button">
              Download C3 for macOS
            </button>
            <button type="button" className="ghost-button">Docs</button>
          </div>
          <div className="hero-links">
            <a href="#platforms">View all platforms</a>
            <a href="#install">Installation Guide</a>
          </div>
        </div>
        <aside className="code-card" aria-label="Code sample">
          <div className="code-toolbar">
            <span />
            <span />
            <span />
            <strong>Hello World</strong>
          </div>
          <pre>
            <code>{`module hello;
import std::io;

fn void main()
{
  io::printn("Hello, World!");
}`}</code>
          </pre>
        </aside>
      </section>

      <section className="split-section">
        <div className="spotlight-list">
          {spotlightFeatures.map((feature) => (
            <article key={feature.title} className="spotlight-item">
              <div className="icon-wrap">{feature.icon}</div>
              <div>
                <h3>{feature.title}</h3>
                <p>{feature.description}</p>
              </div>
            </article>
          ))}
        </div>
        <article className="spotlight-summary">
          <h2>
            C3 is an evolution, not a revolution: <span>the C-like language for programmers who like C.</span>
          </h2>
          <p>
            This portfolio adapts the C3 visual language for a clean, developer-first landing page built in
            TypeScript and React.
          </p>
          <p>
            You get a bold hero, polished feature grid, and practical call-to-action flow designed to keep
            the reading experience familiar and fast.
          </p>
        </article>
      </section>

      <section className="feature-grid">
        {coreFeatures.map((feature) => (
          <article key={feature.title} className="feature-card">
            <div className="feature-icon">{feature.icon}</div>
            <div>
              <h3>{feature.title}</h3>
              <p>{feature.description}</p>
            </div>
          </article>
        ))}
      </section>

      <section className="get-started">
        <h2>
          <span>Get</span> Started
        </h2>
        <div className="start-cards">
          {gettingStartedCards.map((card) => (
            <article key={card.title} className="start-card">
              <div className="start-icon">{card.icon}</div>
              <h3>{card.title}</h3>
              <p>{card.description}</p>
            </article>
          ))}
        </div>
      </section>
    </main>

    <footer className="site-footer">
      <div>
        <span>Next</span>
        <strong>Introduction →</strong>
      </div>
    </footer>
  </div>
);

export default App;
