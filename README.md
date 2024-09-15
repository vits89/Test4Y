# Test4Y

This solution is the result of completing a test task, requirements and explanations for which are contained in the PDF-file.

Note: the solution is no longer based on Nancy framework as it's no longer maintained.

To start the application, run the following command in a terminal:

```console
docker compose up --build
```

Open a browser and view the application at [http://localhost:8080](http://localhost:8080).

Press _Ctrl + C_ in the terminal to stop the application and run the following command to remove containers:

```console
docker compose rm
```

To test the application and get results, run the following commands in the terminal:

```console
docker build -f .\src\Test4Y.WebApiApp\Dockerfile --target test -t test4ywebapiapp-test .
docker run --rm -v .\tests\Test4Y.WebApiApp.UnitTests\TestResults:/src/tests/Test4Y.WebApiApp.UnitTests/TestResults test4ywebapiapp-test
```

Test results will be created in _tests\Test4Y.WebApiApp.UnitTests\TestResults_ folder.
