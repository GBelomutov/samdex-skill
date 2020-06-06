resource "aws_lambda_function" "ap_constantine_healthcheck" {
  filename         = "AP.Constantine.zip"
  function_name    = "apconstantine_healthcheck"
  role             = "${aws_iam_role.aws_ap_constantine.arn}"
  handler          = "AP.Constantine.Functions::AP.Constantine.Functions.HealthCheckFunction::Handle"
  source_code_hash = "${filebase64sha256("AP.Constantine.zip")}"
  runtime          = "dotnetcore3.1"
  timeout          = 10
  memory_size      = 512
}

resource "aws_lambda_function" "ap_constantine_unlink" {
  filename         = "AP.Constantine.zip"
  function_name    = "apconstantine_unlink"
  role             = "${aws_iam_role.aws_ap_constantine.arn}"
  handler          = "AP.Constantine.Functions::AP.Constantine.Functions.UnlinkFunction::Handle"
  source_code_hash = "${filebase64sha256("AP.Constantine.zip")}"
  runtime          = "dotnetcore3.1"
  timeout          = 10
  memory_size      = 512
}

resource "aws_lambda_function" "ap_constantine_devicesList" {
  filename         = "AP.Constantine.zip"
  function_name    = "apconstantine_deviceslist"
  role             = "${aws_iam_role.aws_ap_constantine.arn}"
  handler          = "AP.Constantine.Functions::AP.Constantine.Functions.DeviceListFunction::Handle"
  source_code_hash = "${filebase64sha256("AP.Constantine.zip")}"
  runtime          = "dotnetcore3.1"
  timeout          = 10
  memory_size      = 512
}

resource "aws_lambda_function" "ap_constantine_devicesQuery" {
  filename         = "AP.Constantine.zip"
  function_name    = "apconstantine_devicesquery"
  role             = "${aws_iam_role.aws_ap_constantine.arn}"
  handler          = "AP.Constantine.Functions::AP.Constantine.Functions.DevicesQueryFunction::Handle"
  source_code_hash = "${filebase64sha256("AP.Constantine.zip")}"
  runtime          = "dotnetcore3.1"
  timeout          = 10
  memory_size      = 512
}

resource "aws_lambda_function" "ap_constantine_devicesAction" {
  filename         = "AP.Constantine.zip"
  function_name    = "apconstantine_handledevicecommand"
  role             = "${aws_iam_role.aws_ap_constantine.arn}"
  handler          = "AP.Constantine.Functions::AP.Constantine.Functions.SendCommandFunction::Handle"
  source_code_hash = "${filebase64sha256("AP.Constantine.zip")}"
  runtime          = "dotnetcore3.1"
  timeout          = 10
  memory_size      = 512
}


resource "aws_lambda_permission" "apigw_lambda_healthcheck" {
  statement_id  = "AllowExecutionFromAPIGateway"
  action        = "lambda:InvokeFunction"
  function_name = "${aws_lambda_function.ap_constantine_healthcheck.function_name}"
  principal     = "apigateway.amazonaws.com"

  source_arn = "arn:aws:execute-api:${var.aws_region}:${var.accountId}:${aws_api_gateway_rest_api.api.id}/*/${aws_api_gateway_method.healthcheck.http_method}${aws_api_gateway_resource.apiRoot.path}"
}
resource "aws_lambda_permission" "apigw_lambda_unlink" {
  statement_id  = "AllowExecutionFromAPIGateway"
  action        = "lambda:InvokeFunction"
  function_name = "${aws_lambda_function.ap_constantine_unlink.function_name}"
  principal     = "apigateway.amazonaws.com"

  source_arn = "arn:aws:execute-api:${var.aws_region}:${var.accountId}:${aws_api_gateway_rest_api.api.id}/*/${aws_api_gateway_method.unlink.http_method}${aws_api_gateway_resource.unlink.path}"
}
resource "aws_lambda_permission" "ap_constantine_devicesList" {
  statement_id  = "AllowExecutionFromAPIGateway"
  action        = "lambda:InvokeFunction"
  function_name = "${aws_lambda_function.ap_constantine_devicesList.function_name}"
  principal     = "apigateway.amazonaws.com"

  source_arn = "arn:aws:execute-api:${var.aws_region}:${var.accountId}:${aws_api_gateway_rest_api.api.id}/*/${aws_api_gateway_method.deviceList.http_method}${aws_api_gateway_resource.devicesResource.path}"
}
resource "aws_lambda_permission" "apigw_lambda_devicesQuery" {
  statement_id  = "AllowExecutionFromAPIGateway"
  action        = "lambda:InvokeFunction"
  function_name = "${aws_lambda_function.ap_constantine_devicesQuery.function_name}"
  principal     = "apigateway.amazonaws.com"

  source_arn = "arn:aws:execute-api:${var.aws_region}:${var.accountId}:${aws_api_gateway_rest_api.api.id}/*/${aws_api_gateway_method.deviceState.http_method}${aws_api_gateway_resource.query.path}"
}
resource "aws_lambda_permission" "apigw_lambda_handledevicecommand" {
  statement_id  = "AllowExecutionFromAPIGateway"
  action        = "lambda:InvokeFunction"
  function_name = "${aws_lambda_function.ap_constantine_devicesAction.function_name}"
  principal     = "apigateway.amazonaws.com"

  source_arn = "arn:aws:execute-api:${var.aws_region}:${var.accountId}:${aws_api_gateway_rest_api.api.id}/*/${aws_api_gateway_method.deviceAction.http_method}${aws_api_gateway_resource.action.path}"
}