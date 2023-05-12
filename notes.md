## TODO:
- Setup runner as a service which boots up automatically.
- Setup workflow for scheduled nightly
  - https://docs.github.com/en/actions/using-workflows/events-that-trigger-workflows#schedule
- How to run only specific categories for tests.
- Pull latest vcs in separate step on CI run.

## Benefits
- Sends emails automatically (configurable).
- Faster to execute than Jenkins.
- Easier to configure.
- More user friendly UI.
- Stores artifacts.
- Marketplace has lots of actions to provide functionality.
- Automatically integrated with GitHub/Git.
- More and easier control over runs (e.g. can skip workflow runs)
  - https://docs.github.com/en/actions/managing-workflow-runs/skipping-workflow-runs
- Workflows and code all sit in the same place (GitHub).
