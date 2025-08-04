#!/usr/bin/env bash

if ! pgrep -f "Jenny.Generator.Cli.dll server" >/dev/null; then
  echo "[Jenny] Starting server..."
  dotnet Jenny/Jenny.Generator.Cli.dll server &> jenny-server.log &
  sleep 1
fi

echo "[Jenny] Running client gen..."
dotnet Jenny/Jenny.Generator.Cli.dll client gen
