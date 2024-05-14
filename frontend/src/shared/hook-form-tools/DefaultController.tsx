import { Space } from "antd"
import React from "react"
import { ControllerProps, FieldPath, FieldValues, Path } from "react-hook-form"
import PowerController, { Formater, FormaterValueType, WarningRule, WarningValueType } from "../hook-form-tools/PowerController"

type Props<TFeildValues extends FieldValues, TName extends Path<TFeildValues>> = ControllerProps<TFeildValues, TName>
    & {
        warn?: WarningRule<WarningValueType<TFeildValues, TName>>[],
        label?: string | React.ReactNode,
        labelsStyle?: React.CSSProperties,
        labelGap?: number,
        onWarn?: (warning: string) => void,
        onError?: (error: string) => void,
        formater?: Formater<FormaterValueType<TFeildValues, TName>>
    }

const DefaultController = <TFieldValues extends FieldValues = FieldValues, TName extends FieldPath<TFieldValues> = FieldPath<TFieldValues>>(props: Props<TFieldValues, TName>) => {
    return <PowerController
        {...props}
        render={({ field, fieldState, formState }) => (
            <>
                <div style={{ ...props.labelsStyle, marginBottom: props.labelGap }}>{props.label}</div>
                <Space direction='vertical' size={5} style={{ width: '100%' }}>
                    {props.render({ field, fieldState, formState })}
                    {/* {fieldState.warnings.map((warning, index) => <p key={index} className="input-warn">⚠{warning}</p>)} */}
                    {fieldState.warning && <p className="input-warn">⚠{fieldState.warning}</p>}
                    {fieldState.error?.message && <p className='input-error'>⚠ {fieldState.error.message}</p>}
                </Space>
            </>
        )}
    />
}

export default DefaultController;