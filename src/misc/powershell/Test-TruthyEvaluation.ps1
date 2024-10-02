function Get-NonNullValue {
    return "I'm not null."
}

$sample = Get-NonNullValue
if ($sample) {
    Write-Host "The returned sample wasn't null."
    Write-Host $sample
}

Write-Host "[Done]"