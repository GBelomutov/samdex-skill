resource "aws_api_gateway_account" "constantine_account" {
  cloudwatch_role_arn = "${aws_iam_role.aws_ap_constantine.arn}"
}

resource "aws_api_gateway_rest_api" "api" {
  name = "constantineapi"
}

resource "aws_api_gateway_resource" "apiRoot" {
  path_part   = "v1.0"
  parent_id   = "${aws_api_gateway_rest_api.api.root_resource_id}"
  rest_api_id = "${aws_api_gateway_rest_api.api.id}"
}

resource "aws_api_gateway_resource" "user" {
  path_part   = "user"
  parent_id   = "${aws_api_gateway_resource.apiRoot.id}"
  rest_api_id = "${aws_api_gateway_rest_api.api.id}"
}

resource "aws_api_gateway_resource" "unlink" {
  path_part   = "unlink"
  parent_id   = "${aws_api_gateway_resource.user.id}"
  rest_api_id = "${aws_api_gateway_rest_api.api.id}"
}

resource "aws_api_gateway_resource" "devicesResource" {
  path_part   = "devices"
  parent_id   = "${aws_api_gateway_resource.user.id}"
  rest_api_id = "${aws_api_gateway_rest_api.api.id}"
}

resource "aws_api_gateway_resource" "query" {
  path_part   = "query"
  parent_id   = "${aws_api_gateway_resource.devicesResource.id}"
  rest_api_id = "${aws_api_gateway_rest_api.api.id}"
}

resource "aws_api_gateway_resource" "action" {
  path_part   = "action"
  parent_id   = "${aws_api_gateway_resource.devicesResource.id}"
  rest_api_id = "${aws_api_gateway_rest_api.api.id}"
}



resource "aws_api_gateway_method" "healthcheck" {
  rest_api_id   = "${aws_api_gateway_rest_api.api.id}"
  resource_id   = "${aws_api_gateway_resource.apiRoot.id}"
  http_method   = "HEAD"
  authorization = "NONE"
}

resource "aws_api_gateway_method" "unlink" {
  rest_api_id   = "${aws_api_gateway_rest_api.api.id}"
  resource_id   = "${aws_api_gateway_resource.unlink.id}"
  http_method   = "POST"
  authorization = "NONE"
}

resource "aws_api_gateway_method" "deviceList" {
  rest_api_id   = "${aws_api_gateway_rest_api.api.id}"
  resource_id   = "${aws_api_gateway_resource.devicesResource.id}"
  http_method   = "GET"
  authorization = "NONE"
}

resource "aws_api_gateway_method" "deviceState" {
  rest_api_id   = "${aws_api_gateway_rest_api.api.id}"
  resource_id   = "${aws_api_gateway_resource.query.id}"
  http_method   = "POST"
  authorization = "NONE"
}

resource "aws_api_gateway_method" "deviceAction" {
  rest_api_id   = "${aws_api_gateway_rest_api.api.id}"
  resource_id   = "${aws_api_gateway_resource.action.id}"
  http_method   = "POST"
  authorization = "NONE"
}




resource "aws_api_gateway_integration" "healthcheck_integration" {
  rest_api_id             = "${aws_api_gateway_rest_api.api.id}"
  resource_id             = "${aws_api_gateway_resource.apiRoot.id}"
  http_method             = "${aws_api_gateway_method.healthcheck.http_method}"
  integration_http_method = "POST"
  type                    = "AWS_PROXY"
  uri                     = "${aws_lambda_function.ap_constantine_healthcheck.invoke_arn}"
}

resource "aws_api_gateway_integration" "unlink_integration" {
  rest_api_id             = "${aws_api_gateway_rest_api.api.id}"
  resource_id             = "${aws_api_gateway_resource.unlink.id}"
  http_method             = "${aws_api_gateway_method.unlink.http_method}"
  integration_http_method = "POST"
  type                    = "AWS_PROXY"
  uri                     = "${aws_lambda_function.ap_constantine_unlink.invoke_arn}"
}

resource "aws_api_gateway_integration" "deviceList_integration" {
  rest_api_id             = "${aws_api_gateway_rest_api.api.id}"
  resource_id             = "${aws_api_gateway_resource.devicesResource.id}"
  http_method             = "${aws_api_gateway_method.deviceList.http_method}"
  integration_http_method = "POST"
  type                    = "AWS_PROXY"
  uri                     = "${aws_lambda_function.ap_constantine_devicesList.invoke_arn}"
}

resource "aws_api_gateway_integration" "deviceQuery_integration" {
  rest_api_id             = "${aws_api_gateway_rest_api.api.id}"
  resource_id             = "${aws_api_gateway_resource.query.id}"
  http_method             = "${aws_api_gateway_method.deviceState.http_method}"
  integration_http_method = "POST"
  type                    = "AWS_PROXY"
  uri                     = "${aws_lambda_function.ap_constantine_devicesQuery.invoke_arn}"
}

resource "aws_api_gateway_integration" "deviceAction_integration" {
  rest_api_id             = "${aws_api_gateway_rest_api.api.id}"
  resource_id             = "${aws_api_gateway_resource.action.id}"
  http_method             = "${aws_api_gateway_method.deviceAction.http_method}"
  integration_http_method = "POST"
  type                    = "AWS_PROXY"
  uri                     = "${aws_lambda_function.ap_constantine_devicesAction.invoke_arn}"
}