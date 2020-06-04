provider "aws" {
  profile = "${var.aws_profile}"
  region  = "${var.aws_region}"
}

data "template_file" "apconstantine_aws_iam_role_template" {
  template = "${file("${path.module}/aws-iam-role.json")}"
}

data "template_file" "apconstantine_aws_iam_role_policy_template" {
  template = "${file("${path.module}/aws-iam-role-policy.json")}"
}

resource "aws_iam_role" "aws_ap_constantine" {
  name               = "ap_constantine_aws_iam_role"
  assume_role_policy = "${data.template_file.apconstantine_aws_iam_role_template.rendered}"
}

resource "aws_iam_role_policy" "aws_ap_constantine" {
  name = "ap_constantine_aws_iam_role_policy"
  role = "${aws_iam_role.aws_ap_constantine.id}"
  policy = "${data.template_file.apconstantine_aws_iam_role_policy_template.rendered}"
}