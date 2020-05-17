resource "aws_lambda_permission" "apigw_lambda" {
  statement_id  = "AllowExecutionFromAPIGateway"
  action        = "lambda:InvokeFunction"
  function_name = "${aws_lambda_function.ap_constantine.function_name}"
  principal     = "apigateway.amazonaws.com"

  source_arn = "arn:aws:execute-api:${var.aws_region}:${var.accountId}:${aws_api_gateway_rest_api.api.id}/*/${aws_api_gateway_method.method.http_method}${aws_api_gateway_resource.resource.path}"
}

resource "aws_lambda_function" "ap_constantine" {
  filename         = "AP.Constantine.zip"
  function_name    = "apconstantine_commandprocessing"
  role             = "${aws_iam_role.aws_ap_constantine.arn}"
  handler          = "AP.Constantine.Functions::AP.Constantine.Functions.ConstantineHandler::Run"
  source_code_hash = "${filebase64sha256("AP.Constantine.zip")}"
  runtime          = "dotnetcore3.1"
  timeout          = 10
  memory_size      = 512
}
