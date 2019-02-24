@ECHO OFF

ECHO Building docs..

docfx metadata docfx_project/docfx.json

docfx build docfx_project/docfx.json